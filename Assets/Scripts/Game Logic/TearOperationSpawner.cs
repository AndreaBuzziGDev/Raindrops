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

    // Start is called before the first frame update
    void Start()
    {
        Vector3 v1 = Vector3.Lerp(leftEnd, rightEnd, 0);
        Vector3 v2 = Vector3.Lerp(leftEnd, rightEnd, 0.25f);
        Vector3 v3 = Vector3.Lerp(leftEnd, rightEnd, 0.5f);
        Vector3 v4 = Vector3.Lerp(leftEnd, rightEnd, 0.75f);
        Vector3 v5 = Vector3.Lerp(leftEnd, rightEnd, 1);
        Debug.Log("Vector 1: " + v1);
        Debug.Log("Vector 2: " + v2);
        Debug.Log("Vector 3: " + v3);
        Debug.Log("Vector 4: " + v4);
        Debug.Log("Vector 5: " + v5);
    }

    //GIZMO DRAWING
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(leftEnd, rightEnd);

    }





    //UTILITIES
    //TODO: SOLVE POTENTIAL OVERLOADING ISSUES BY USING AN OPTIONAL PARAMETER
    public Vector3 GetRandomPosition()
    {
        float myRandom = UnityEngine.Random.Range(0.0f, 1.0f);
        return Vector3.Lerp(leftEnd, rightEnd, myRandom);
    }



}
