using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearOperationData
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
    private EOperation operation;
    
    //TODO: THESE SHOULD BE INTEGERS. PROBLEMS WILL ENSUE WITH FLOATS.
    private float numberOneValue = 1;
    private float numberTwoValue = 1;


    //TECHNICAL DATA
    public static Dictionary<EOperation, string> dictionaryEOP = new Dictionary<EOperation, string>
    {
        {EOperation.SUM, "+"},
        {EOperation.DIFFERENCE, "-"},
        {EOperation.MULTIPLICATION, "x"},
        {EOperation.DIVISION, "/"}
    };


    //CONSTRUCTOR



    //FUNCTIONALITIES
    private float Result {
        get {
            switch (operation)
            {
                case EOperation.SUM:
                    return numberOneValue + numberTwoValue;
                case EOperation.DIFFERENCE:
                    return numberOneValue - numberTwoValue;
                case EOperation.MULTIPLICATION:
                    return numberOneValue * numberTwoValue;
                case EOperation.DIVISION:
                    return numberOneValue / numberTwoValue;
                default:
                    Debug.LogError("Invalid operation value has been provided");
                    return 0;
            }
        }
    }

}
