using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TearOperation : MonoBehaviour
{
    //ENUMS
    public enum EOperation
    {
        SUM,
        DIFFERENCE,
        MULTIPLICATION,
        DIVISION
    }


    //DATA
    [SerializeField] private float tearSpeed = 1.0f;
    [SerializeField] private EOperation operation = EOperation.SUM;//TODO: THIS DOES NOT NEED TO BE A SERIALIZED FIELD AND SHOULD NOT BE.



    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //SET POSITION TO STANDARD POSITION
        //TODO: MOVE TO APPROPRIATE POSITION

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(0, tearSpeed * Time.fixedDeltaTime, 0);
    }




    //FUNCTIONALITIES



}
