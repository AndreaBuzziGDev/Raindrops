using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearOperationSpawner : MonoSingleton<TearOperationSpawner>
{
    //DATA
    [SerializeField] Vector3 leftEnd = new Vector3(-8, 6, 0);
    [SerializeField] Vector3 rightEnd = new Vector3(8, 6, 0);
    //NB: LEFT AND RIGHT CAN BE LERP-ED TO GENERATE RANDOM SPAWN COORDINATES



    //LIFECYCLE FUNCTIONS
    //...




    //UTILITIES
    public Vector3 GetRandomPosition()
    {
        float myRandom = UnityEngine.Random.Range(0.0f, 1.0f);
        return Vector3.Lerp(leftEnd, rightEnd, myRandom);
    }



    //GIZMO DRAWING
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(leftEnd, rightEnd);

    }

}
