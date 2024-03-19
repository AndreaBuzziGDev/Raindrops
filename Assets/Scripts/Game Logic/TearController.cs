using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearController : MonoSingleton<TearController>
{
    //DATA
    //TODO: SHOULD CONTAIN DATA STRUCTURES FOR HANDLING POOLING AND OTHER STUFF


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



    
    
    //UTILITIES
    
    
}
