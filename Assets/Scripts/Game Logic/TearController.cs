using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        TearOperationLowerBoundary.TearLost += HandleTearLost;
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: THIS SHOULD HANDLE POOLING OF OBJECTS
        
    }
    



    //EVENT HANDLING
    public void HandleTearLost(object sender, TearLostEventArgs e)
    {
        /*
        Debug.Log("Tear Lost Logic on TearController");
        Debug.Log("Sender: " + sender);
        */

        //
        

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
        
        
        //TODO: MIGHT NEED TO COLLECT DATA ON THE DESTROYED OBJECT FOR POOLING PURPOSES


        //TODO: ENQUEUE THE SPAWN

        
        //TODO: HANDLE AN EFFECT FOR TEAR DESTRUCTION (SPRITE ANIMATION, PARTICLE EFFECT...)
        
        
        //DESTROY
        Destroy(toDestroy);

        //SPAWN NEW
        SpawnTear();
    }
    
    
    //UTILITIES
    
    
}
