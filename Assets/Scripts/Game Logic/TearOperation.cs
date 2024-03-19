using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

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

    private float numberOneValue = 5;
    private float numberTwoValue = 4;

    private float result = 0;



    private Dictionary<EOperation, string> dictionaryEOP = new Dictionary<EOperation, string>
    {
        {EOperation.SUM, "+"},
        {EOperation.DIFFERENCE, "-"},
        {EOperation.MULTIPLICATION, "x"},
        {EOperation.DIVISION, "/"}
    };





    //PREFAB REFERENCES
    [SerializeField] private TMP_Text textNumberOne;
    [SerializeField] private TMP_Text textNumberTwo;
    [SerializeField] private TMP_Text textOperation;




    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //SET POSITION TO STANDARD POSITION
        //TODO: MOVE THE SETTING OF THE TRANSFORM STARTING POSITION ELSEWHERE, POSSIBLY IN THE SPAWNER ITSELF
        //TODO: THE SPAWNER SHOULD ALSO INSTANTIATE PREFABS
        transform.position = TearOperationSpawner.Instance.GetRandomPosition();
        
        //SETS THE VISUAL CONTENT OF THE PREFAB
        SetContent();
        CalcResult();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + tearSpeed * Time.fixedDeltaTime * Vector3.down;
    }




    //FUNCTIONALITIES
    private void SetContent()
    {
        textNumberOne.text = numberOneValue.ToString();
        textNumberTwo.text = numberTwoValue.ToString();
        textOperation.text = dictionaryEOP[operation];
    }

    private void CalcResult()
    {
        switch (operation)
        {
            case EOperation.SUM:
                result = numberOneValue + numberTwoValue;
                break;
            case EOperation.DIFFERENCE:
                result = numberOneValue - numberTwoValue;
                break;
            case EOperation.MULTIPLICATION:
                result = numberOneValue * numberTwoValue;
                break;
            case EOperation.DIVISION:
                result = numberOneValue / numberTwoValue;
                break;
            default:
                Debug.LogError(this.gameObject.name + " has no valid operation value.");
                result = 0;
                break;
        }
        //TODO: DISMISS DEBUG
        Debug.Log(this.gameObject.name + " - Result: " + result);
    }


}
