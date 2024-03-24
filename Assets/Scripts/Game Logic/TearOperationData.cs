using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    
    private int numberOneValue;
    private int numberTwoValue;


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




    //TECHNICAL DATA
    public static Dictionary<EOperation, string> dictionaryEOP = new Dictionary<EOperation, string>
    {
        {EOperation.SUM, "+"},
        {EOperation.DIFFERENCE, "-"},
        {EOperation.MULTIPLICATION, "x"},
        {EOperation.DIVISION, "/"}
    };


    //CONSTRUCTOR
    public TearOperationData(int numberOne = 1, int numberTwo = 1, EOperation operation = EOperation.SUM){
        numberOneValue = numberOne;
        numberTwoValue = numberTwo;
        this.operation = operation;
    }



    //RANDOMIZATION
    public EOperation GetRandomOperation()
    {
        int randomInt = UnityEngine.Random.Range(0, EOperation.GetNames(typeof(EOperation)).Length);
        return (EOperation) randomInt;
    }
    
    //TODO: THIS MIGHT BE BETTER IF IMPLEMENTED IN ANOTHER WAY (EG: IN CONSTRUCTOR)
    public int GetRandomNumberOne(EOperation operation = EOperation.SUM)
    {
        switch (operation)
            {
                case EOperation.SUM:
                    return UnityEngine.Random.Range(0, 10);
                case EOperation.DIFFERENCE:
                    return UnityEngine.Random.Range(0, 10);
                case EOperation.MULTIPLICATION:
                    return UnityEngine.Random.Range(0, 10);
                case EOperation.DIVISION:
                    return UnityEngine.Random.Range(1, 10);
                default:
                    Debug.LogError("Invalid operation value has been provided");
                    return 0;
            }
    }

    //TODO: IMPROVE AND EXPAND UPON
    public int GetRandomNumberTwo(EOperation operation = EOperation.SUM)
    {
        return GetRandomNumberOne(operation);
    }
    

}
