using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TearOperationLowerBoundary : MonoBehaviour
{
    //EVENTS
    //TODO: DEEPEN THE STUDY FOR EVENT DELEGATES
    public static event EventHandler<TearLostEventArgs> TearLost;


    //DATA
    


    //LIFECYCLE FUNCTIONS


    //FUNCTIONALITIES
    void OnTriggerEnter2D(Collider2D coll)
    {
        TearOperation tear = coll.gameObject?.GetComponent<TearOperation>();
        if(tear != null)
        {
            Debug.Log("Collision");

            TearLostEventArgs myTearLostEvent = new TearLostEventArgs(tear);
            OnTearLost(myTearLostEvent);
            //TODO: DESTROY TEAR - NB: MOVED IN APPROPRIATE SCRIPT
            //TODO: EVENTUALLY HANDLE THE REST OF THE GAME LOGIC - NB: MOVED IN APPROPRIATE SCRIPT
        }
    }


    //TODO: DRAW A GIZMO ON THE SCREEN FOR DEBUG REASONS, SO THAT THE COLLIDER IS VISIBLE IN THE EDITOR AND ONLY IN THE EDITOR


    
    //EVENT-FIRING METHOD
    private void OnTearLost(TearLostEventArgs myEventArg) => TearLost?.Invoke(this, myEventArg);

}
