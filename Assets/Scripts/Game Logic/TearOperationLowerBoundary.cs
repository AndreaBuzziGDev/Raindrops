using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TearOperationLowerBoundary : MonoBehaviour
{
    //EVENTS
    public static event EventHandler<TearEventArgs> TearLost;


    //DATA
    


    //LIFECYCLE FUNCTIONS


    //FUNCTIONALITIES
    void OnTriggerEnter2D(Collider2D coll)
    {
        TearOperation tear = coll.gameObject?.GetComponent<TearOperation>();
        if(tear != null)
        {
            Debug.Log("Collision");

            TearEventArgs myTearLostEvent = new TearEventArgs(tear);
            OnTearLost(myTearLostEvent);
        }
    }




    //GIZMO DRAWING
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);

    }

    
    //EVENT-FIRING METHOD
    private void OnTearLost(TearEventArgs myEventArg) => TearLost?.Invoke(this, myEventArg);


}
