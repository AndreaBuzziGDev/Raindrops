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
    private int numberOneValue;
    private int numberTwoValue;



    //DATA GETTERS
    public EOperation Operation { get {return operation; } }
    public int NumberOneValue { get {return numberOneValue; } }
    public int NumberTwoValue { get {return numberTwoValue; } }

    public int Result {
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

        this.operation = operation;
        switch(operation)
        {
            case EOperation.DIVISION:
                numberOneValue = numberOne * numberTwo;
                numberTwoValue = numberTwo;
                break;
            default:
                numberOneValue = numberOne;
                numberTwoValue = numberTwo;
                break;
        }
    }



    //RANDOMIZATION
    public static EOperation GetRandomOperation()
    {
        return (EOperation) UnityEngine.Random.Range(0, EOperation.GetNames(typeof(EOperation)).Length);
    }
    
    public static int GetRandomNumberOne(EOperation operation = EOperation.SUM)
    {
        switch (operation)
        {
            case EOperation.SUM:
                return UnityEngine.Random.Range(1, 10);
            case EOperation.DIFFERENCE:
                return UnityEngine.Random.Range(1, 10);
            case EOperation.MULTIPLICATION:
                return UnityEngine.Random.Range(1, 10);
            case EOperation.DIVISION:
                return UnityEngine.Random.Range(1, 10);
            default:
                Debug.LogError("Invalid operation value has been provided");
                return 0;
        }
    }

    //TODO: IMPROVE AND EXPAND UPON
    public static int GetRandomNumberTwo(EOperation operation = EOperation.SUM)
    {
        switch (operation)
        {
            case EOperation.SUM:
                return UnityEngine.Random.Range(0, 10);
            case EOperation.DIFFERENCE:
                return UnityEngine.Random.Range(0, 10);
            case EOperation.MULTIPLICATION:
                return UnityEngine.Random.Range(2, 10);
            case EOperation.DIVISION:
                return UnityEngine.Random.Range(1, 10);
            default:
                Debug.LogError("Invalid operation value has been provided");
                return 0;
        }
    }

    //NB: THIS CANNOT BE EASILY SET FROM A SCRIPTABLE OBJECT BECAUSE THIS IS NOT MONOBEHAVIOUR. NEEDS SOME "WIRING" TO WORK.
    public int GetTearScore()
    {
        switch (operation)
        {
            case EOperation.SUM:
                return 1;
            case EOperation.DIFFERENCE:
                return 2;
            case EOperation.MULTIPLICATION:
                return 5;
            case EOperation.DIVISION:
                return 2;
            default:
                Debug.LogError("Invalid operation value has been provided");
                return 0;
        }
    }
    
}
