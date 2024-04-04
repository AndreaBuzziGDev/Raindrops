using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TearController : MonoSingleton<TearController>
{
    //DATA
    
    //TODO: SEPARATE IN SECTIONS IN THE EDITOR THESE THINGS
    //GAMEPLAY SETTINGS
    [SerializeField] int maxConcurrentItems = 3;
    [SerializeField] int maxItemsPerSpawnIteration = 1;
    [SerializeField] float maxSpawnIterationCooldown = 1.0f;
    [SerializeField] int maxLives = 3;
    [Range(0, 100)][SerializeField] int goldChance = 10;


    //GAMEPLAY STATS
    int concurrentItems;
    float spawnIterationCooldown;
    float score;
    int lives;

    //SAVE-RELATED STATS
    float existingHighScore;

    //DATA METHODS
    public bool IsMaxConcurrentItems { get { return maxConcurrentItems <= concurrentItems; } }
    public bool IsGameOverCondition { get { return lives <= 0; } }




    //DIFFICULTY COEFFICIENTS
    int gameDifficultyValue;
    [SerializeField] List<DifficultySettingSO> difficultySettings = new ();

    //NB: THESE COULD BE EVOLVED WITH SCRIPTABLEOBJECTS
    Dictionary<int, float> speedCoefficientMapping = new();
    public float SpeedDifficultyValue { get { return speedCoefficientMapping[gameDifficultyValue]; } }

    Dictionary<int, float> scoreCoefficientMapping = new();
    public float ScoreDifficultyCoefficient { get { return scoreCoefficientMapping[gameDifficultyValue]; } }


    //PREFABS
    [SerializeField] TearOperation tearOpPrefab;
    [SerializeField] TearOperation goldOpPrefab;





    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //LISTEN EVENTS
        TearOperationLowerBoundary.TearLost += HandleTearEvent;
        TearOperation.TearSolved += HandleTearEvent;

        //INIZIALIZE SCENE
        List<TearOperation> initialTears = FindObjectsOfType<TearOperation>().ToList();
        concurrentItems = initialTears.Count;

        //INITIALIZE GAME STATS
        lives = maxLives;
        UI_RaindropsGame.Instance.SetScore(score);
        UI_RaindropsGame.Instance.SetLives(lives);
        
        //INITIALIZE DIFFICULTY SETTINGS
        gameDifficultyValue = UtilsPrefs.GameSettings.GetGameSpeed();
        InitializeDifficultyMapping();

        //INITIALIZE GAME SCORE
        SaveGameStats sgs = (SaveGameStats) UtilsSave.LoadSave(SaveController.defaultGameStatsName);
        existingHighScore = sgs==null ? 0 : sgs.HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        
        //TODO: COULD THIS PART BE A METHOD?
        if(spawnIterationCooldown > 0){
            spawnIterationCooldown -= Time.deltaTime;
            spawnIterationCooldown = Math.Clamp(spawnIterationCooldown, 0, maxSpawnIterationCooldown);
        }
        else
        {
            int spawnedItemsIteration = 0;
            while (spawnedItemsIteration < maxItemsPerSpawnIteration && !IsMaxConcurrentItems)
            {
                SpawnTear();
                spawnedItemsIteration++;
            }
        }
        //
        
    }

    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        TearOperationLowerBoundary.TearLost -= HandleTearEvent;
        TearOperation.TearSolved -= HandleTearEvent;
    }
    



    //EVENT HANDLING
    private void HandleTearEvent(object sender, TearEventArgs e)
    {
        //LOSS
        if(e.EventType == TearEventArgs.EType.LOSS) DestroyTear(e.LostTear);

        //SUCCESS
        if(e.EventType == TearEventArgs.EType.SUCCESS) SolveTear(e.LostTear);

    }




    //FUNCTIONALITIES
    private void SpawnTear()
    {
        //RANDOM GOLD OR NOT
        int goldenInt = UnityEngine.Random.Range(0, 100);
        TearOperation prefabToInstantiate = goldenInt > goldChance ? tearOpPrefab : goldOpPrefab;

        //INSTANTIATE TearOperation
        Instantiate(
            prefabToInstantiate, 
            TearOperationSpawner.Instance.GetRandomPosition(), 
            Quaternion.identity
        );
        concurrentItems++;
        spawnIterationCooldown = maxSpawnIterationCooldown;
    }

    private void DestroyTear(TearOperation toDestroy)
    {
        Vector3 tearPosition = toDestroy.transform.position;
        Debug.Log("Destroy Tear at Position: " + tearPosition);

        //TODO: HANDLE AN EFFECT FOR TEAR DESTRUCTION (SPRITE ANIMATION, PARTICLE EFFECT...)

        //HANDLING GAME STATS
        lives--;
        UI_RaindropsGame.Instance.SetLives(lives);

        if(IsGameOverCondition)
            GameController.Instance.SetState(GameController.EGameState.GameOver);

        //DESTROY
        Destroy(toDestroy.gameObject);
        concurrentItems--;
    }
    

    private void SolveTear(TearOperation solvedTear)
    {
        //TODO: HANDLE AN EFFECT FOR TEAR SOLUTION (SPRITE ANIMATION, PARTICLE EFFECT...)

        //HANDLE SCORE
        score += ScoreDifficultyCoefficient * solvedTear.TOData.GetTearScore();
        UI_RaindropsGame.Instance.SetScore(score);
        if(score > existingHighScore)
        {
            //TODO: IMPROVE SAVE CONDITION (DON'T KEEP SPAMMING SAVES ON DISC)
            Debug.Log("new highScore: " + score);
            existingHighScore = score;
            SaveGameStats sgs = new(SaveController.defaultGameStatsName, existingHighScore);
            UtilsSave.CreateSave(sgs.FileName, sgs);
            //NB: MARK ON UI SO THAT NEW HIGH SCORE IS KNOWN
            //...
        }

        //DESTROY
        Destroy(solvedTear.gameObject);
        concurrentItems--;
    }


    private void InitializeDifficultyMapping()
    {
        //NB: EVOLVE TO HANDLE MISSING DIFFICULTIES IN SETTINGS?
        if(difficultySettings.Count > 0)
        {
            foreach(DifficultySettingSO dsSO in difficultySettings)
            {
                speedCoefficientMapping.Add((int) dsSO.DifficultyValue, dsSO.SpeedCoefficient);
                scoreCoefficientMapping.Add((int) dsSO.DifficultyValue, dsSO.ScoreCoefficient);
            }
        }
        else 
        {
            foreach (int i in Enum.GetValues(typeof(UtilsPrefs.GameSettings.DIFFICULTY)))
            {
                speedCoefficientMapping.Add(i, 1);
                scoreCoefficientMapping.Add(i, 1);
            }
            Debug.LogError("NO DIFFICULTY SETTINGS, DEFAULTING TO 1x FOR EACH DIFFICULTY");
        }
    }
}
