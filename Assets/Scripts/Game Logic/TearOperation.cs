using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class TearOperation : MonoBehaviour
{
    //ENUMS
    public enum ETearType
    {
        NORMAL,
        GOLD
    }


    //EVENTS
    public static event EventHandler<TearEventArgs> TearSolved;


    //DATA
    [Header("Tear Settings")]
    [SerializeField] ETearType tearType = ETearType.NORMAL;
    [SerializeField] float trueSpeed = 1.0f;
    float speedDiffCoeff = 1.0f;

    //DEBUG MODE
    [Header("Debug Settings")]
    [SerializeField] bool debugMode = false;
    [SerializeField] float debugSpeed = 1.0f;
    [SerializeField] bool debugSpeedDifficulty = false;
    [SerializeField] int debugValueTop = 5;
    [SerializeField] int debugValueBottom = 4;
    [SerializeField] TearOperationData.EOperation debugOperation = 0;

    //PREFAB REFERENCES
    [Header("Prefab References")]
    [SerializeField] private TMP_Text textNumberOne;
    [SerializeField] private TMP_Text textNumberTwo;
    [SerializeField] private TMP_Text textOperation;


    ///DATA WRAPPER CLASS
    private TearOperationData myData;
    public TearOperationData TOData { get { return myData; } }
    
    ///INPUT - EVENT-DRIVEN IMPLEMENTATION
    private RaindropsAction inputPlayer = null;




    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //LISTEN TO EVENTS
        UI_RaindropsGame.ResultInput += HandleResultInput;

        //LISTENS TO OWN-EVENT FOR HANDLING GOLDEN SOLUTIONS
        TearSolved += HandleGoldenSolution;

        //SETTING DATA
        TearOperationData.EOperation randomOp = TearOperationData.GetRandomOperation();
        if(debugMode)
            myData = new TearOperationData(debugValueTop, debugValueBottom, debugOperation);
        else
            myData = new TearOperationData(TearOperationData.GetRandomNumberOne(randomOp), TearOperationData.GetRandomNumberOne(randomOp), randomOp);
        
        //DIFFICULTY SETTING
        speedDiffCoeff = TearController.Instance.SpeedDifficultyValue;

        //SETS THE VISUAL CONTENT OF THE PREFAB
        SetVisibleContent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO: SHOULD LISTEN FOR ESC PRESS INSTEAD OF SETTING VISIBLE CONTENT OR AN EQUIVALENT?
        if(GameController.Instance.IsPlaying){
            SetVisibleContent();
            HandleMovement();
        }
        else
        {
            SetVisibleContent(false);
        }
    }

    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        UI_RaindropsGame.ResultInput -= HandleResultInput;
        TearSolved -= HandleGoldenSolution;
    }



    //EVENT HANDLING
    public void HandleResultInput(object sender, ResultInputEventArgs e)
    {
        //IF RESULT CORRECT = FIRE SOLUTION EVENT
        if(e.InputValue == this.myData.Result)
        {
            TearEventArgs myTearLostEvent = new(this, TearEventArgs.EType.SUCCESS);
            OnTearSolved(myTearLostEvent);
        }
    }

    public void HandleGoldenSolution(object sender, TearEventArgs e)
    {
        //GOLD TEARS DON'T EXPLODE FOR GOLD TEARS
        if(tearType != ETearType.GOLD && e.LostTear.tearType == ETearType.GOLD)
        {
            TearEventArgs myTearLostEvent = new(this, TearEventArgs.EType.SUCCESS);
            OnTearSolved(myTearLostEvent);
        }
    }



    //FUNCTIONALITIES
    private void SetVisibleContent(bool visible = true)
    {
        if(visible)
        {
            textNumberOne.text = myData.NumberOneValue.ToString();
            textOperation.text = TearOperationData.dictionaryEOP[myData.Operation];
            textNumberTwo.text = myData.NumberTwoValue.ToString();
        }
        else
        {
            textNumberOne.text = ">:y";
            textOperation.text = "?";
            textNumberTwo.text = ">:c";
        }
    }

    private void HandleMovement()
    {
        Vector3 translation;
        if(debugMode){
            if(debugSpeedDifficulty)
                translation = speedDiffCoeff * debugSpeed * Time.fixedDeltaTime * Vector3.down;
            else
                translation = debugSpeed * Time.fixedDeltaTime * Vector3.down;
        } else {
            translation = speedDiffCoeff * trueSpeed * Time.fixedDeltaTime * Vector3.down;
        }

        transform.position += translation;
    }



    //EVENT-FIRING METHOD
    private void OnTearSolved(TearEventArgs myEventArg) => TearSolved?.Invoke(this, myEventArg);

}
