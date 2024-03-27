using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TearController : MonoSingleton<TearController>
{
    //DATA
    //TODO: SHOULD CONTAIN DATA STRUCTURES FOR HANDLING POOLING AND OTHER STUFF
    
    //GAMEPLAY SETTINGS
    [SerializeField] int maxConcurrentItems = 3;
    [SerializeField] int maxItemsPerSpawnIteration = 1;
    [SerializeField] int itemsAtSpawn = 2;
    [SerializeField] float maxSpawnIterationCooldown = 1.0f;


    //GAMEPLAY STATS
    int concurrentItems;
    float spawnIterationCooldown;


    //DATA METHODS
    public bool IsMaxConcurrentItems { get { return maxConcurrentItems <= concurrentItems; } }



    
    
    //PREFABS
    [SerializeField] TearOperation tearOpPrefab;





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

        //TODO: THIS SHOULD START WITH POOLED OPERATIONS
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: THIS SHOULD HANDLE POOLING OF OBJECTS
        
        //TODO: COULD THIS PART BE A METHOD?
        if(spawnIterationCooldown > 0)
            spawnIterationCooldown -= Time.deltaTime;
        
        if(!IsMaxConcurrentItems && spawnIterationCooldown <= 0)
        {
            int spawnedItemsIteration = 0;
            while (spawnedItemsIteration <= maxItemsPerSpawnIteration)
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
    public void HandleTearEvent(object sender, TearEventArgs e)
    {
        /*
        Debug.Log("Tear Lost Logic on TearController");
        Debug.Log("Sender: " + sender);
        */

        //LOSS
        if(e.EventType == TearEventArgs.EType.LOSS) DestroyTear(e.LostTear);

        //SUCCESSS
        if(e.EventType == TearEventArgs.EType.SUCCESS) SolveTear(e.LostTear);

    }




    //FUNCTIONALITIES
    //TODO: MIGHT HAVE SENSE TO RETURN THE SPAWNED TEAR
    private void SpawnTear()
    {
        //TODO: MIGHT NEED TO PICK FROM OBJECT POOL

        //TODO: RANDOMIZE
        Vector3 newPosition = TearOperationSpawner.Instance.GetRandomPosition();
        Instantiate(tearOpPrefab, newPosition, Quaternion.identity);
        concurrentItems++;
        spawnIterationCooldown = maxSpawnIterationCooldown;
    }

    //TODO: BOTH SOLVE AND DESTROY SHOULD NOT INSTANTIATE ONE IMMEDIATELY BUT RATHER QUEUE AN INSTANTIATION IN THE POOLER
    private void DestroyTear(TearOperation toDestroy)
    {
        Vector3 tearPosition = toDestroy.transform.position;
        Debug.Log("Destroy Tear at Position: " + tearPosition);
        
        //TODO: PART OF THIS LOGIC PROBABLY CAN BE SIMPLIFIED AND METHOD MADE MORE API-FIED
        
        //TODO: MIGHT NEED TO COLLECT DATA ON THE DESTROYED OBJECT FOR POOLING PURPOSES


        //TODO: ENQUEUE THE SPAWN

        
        //TODO: HANDLE AN EFFECT FOR TEAR DESTRUCTION (SPRITE ANIMATION, PARTICLE EFFECT...)
        
        
        //DESTROY
        Destroy(toDestroy.gameObject);
        concurrentItems--;
    }
    

    private void SolveTear(TearOperation solvedTear)
    {
        //TODO: SHOULD PROBABLY CALL GameController TO HANDLE SCORE AND STUFF?
        Debug.Log("Solved Tear: " + solvedTear.gameObject.name);

        //TODO: HANDLE AN EFFECT FOR TEAR SOLUTION (SPRITE ANIMATION, PARTICLE EFFECT...)

        //DESTROY
        Destroy(solvedTear.gameObject);
        concurrentItems--;
    }
    
    //UTILITIES
    


}
