using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TearController : MonoSingleton<TearController>
{
    //DATA
    
    //GAMEPLAY SETTINGS
    [Header("Gameplay Settings")]
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
    
    [Header("Difficulty Settings")]
    [SerializeField] List<DifficultySettingSO> difficultySettings = new ();

    //NB: THESE COULD BE EVOLVED WITH SCRIPTABLEOBJECTS
    Dictionary<int, float> speedCoefficientMapping = new();
    public float SpeedDifficultyValue { get { return speedCoefficientMapping[gameDifficultyValue]; } }

    Dictionary<int, float> scoreCoefficientMapping = new();
    public float ScoreDifficultyCoefficient { get { return scoreCoefficientMapping[gameDifficultyValue]; } }


    //PREFABS
    [Header("Prefab Links")]
    [SerializeField] TearOperation tearOpPrefab;
    [SerializeField] TearOperation goldOpPrefab;


    //EVENTS
    public static event EventHandler<HighScoreEventArgs> OnNewHighScore;





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
        TearManagement();
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
        if(e.EventType == TearEventArgs.EType.LOSS) DestroyTear(e.AffectedTear);

        //SUCCESS
        if(e.EventType == TearEventArgs.EType.SUCCESS) SolveTear(e.AffectedTear);

    }




    //FUNCTIONALITIES
    private void TearManagement()
    {
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
    }


    //TEAR OPERATIONS
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
        //HANDLE SCORE
        score += ScoreDifficultyCoefficient * solvedTear.TOData.GetTearScore();
        UI_RaindropsGame.Instance.SetScore(score);
        if(score > existingHighScore)
        {
            existingHighScore = score;
            SaveGameStats sgs = new(SaveController.defaultGameStatsName, existingHighScore);
            UtilsSave.CreateSave(sgs.FileName, sgs);
            
            //
            HighScoreEventArgs myEventArg = new ((int) existingHighScore);
            OnTearLost(myEventArg);
        }

        //DESTROY
        Destroy(solvedTear.gameObject);
        concurrentItems--;
    }

    
    //INITIALIZATION
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


    //EVENT-FIRING METHOD
    private void OnTearLost(HighScoreEventArgs myEventArg) => OnNewHighScore?.Invoke(this, myEventArg);

}
