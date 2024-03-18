using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearOperationSpawner : MonoBehaviour
{
    //DATA
    [SerializeField] Vector3 leftEnd = new Vector3(-8, 6, 0);
    [SerializeField] Vector3 rightEnd = new Vector3(8, 6, 0);




    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //GIZMO DRAWING
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(leftEnd, rightEnd);

    }




}
