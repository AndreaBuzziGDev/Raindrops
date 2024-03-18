using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearOperationLowerBoundary : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        TearOperation tear = coll.gameObject?.GetComponent<TearOperation>();
        if(tear != null)
        {
            Debug.Log("Collision");
            //TODO: DESTROY TEAR
            //TODO: EVENTUALLY HANDLE THE REST OF THE GAME LOGIC
            //TODO: SHOULD REALLY CAST AN EVENT AND LET SOMETHING ELSE HANDLE IT
        }
    }

}
