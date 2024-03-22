using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TearController : MonoSingleton<TearController>
{
    //DATA
    //TODO: SHOULD CONTAIN DATA STRUCTURES FOR HANDLING POOLING AND OTHER STUFF
    
    
    
    //PREFABS
    [SerializeField] TearOperation tearOpPrefab;





    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //TODO: THIS SHOULD INITIALIZE A NUMBER OF TEAR OPERATIONS (AND POOL IT AT A LATER STAGE)
        TearOperationLowerBoundary.TearLost += HandleTearEvent;
        TearOperation.TearSolved += HandleTearEvent;
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: THIS SHOULD HANDLE POOLING OF OBJECTS
        
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
    //TODO: MIGHT NEED SIGNATURE
    private void SpawnTear()
    {
        //TODO: MIGHT NEED TO PICK FROM OBJECT POOL

        //TODO: RANDOMIZE
        Vector3 newPosition = TearOperationSpawner.Instance.GetRandomPosition();
        Instantiate(tearOpPrefab, newPosition, Quaternion.identity);

    }


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

        //SPAWN NEW
        SpawnTear();
    }
    

    private void SolveTear(TearOperation solvedTear)
    {
        //TODO: SHOULD PROBABLY CALL GameController TO HANDLE SCORE AND STUFF?
        Debug.Log("Solved Tear: " + solvedTear.gameObject.name);

        //TODO: HANDLE AN EFFECT FOR TEAR SOLUTION (SPRITE ANIMATION, PARTICLE EFFECT...)

        //DESTROY
        Destroy(solvedTear.gameObject);

        //SPAWN NEW
        SpawnTear();
    }
    
    //UTILITIES
    


}
