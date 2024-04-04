using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class TearOperation : MonoBehaviour
{
    //EVENTS
    public static event EventHandler<TearEventArgs> TearSolved;


    //DATA
    [SerializeField] float trueSpeed = 1.0f;
    float speedDiffCoeff = 1.0f;

    private TearOperationData myData;
    public TearOperationData TOData { get { return myData; } }



    //DEBUG MODE
    [SerializeField] bool debugMode = false;
    [SerializeField] float debugSpeed = 1.0f;
    [SerializeField] bool debugSpeedDifficulty = false;
    [SerializeField] int debugValueTop = 5;
    [SerializeField] int debugValueBottom = 4;
    [SerializeField] TearOperationData.EOperation debugOperation = 0;



    //PREFAB REFERENCES
    [SerializeField] private TMP_Text textNumberOne;
    [SerializeField] private TMP_Text textNumberTwo;
    [SerializeField] private TMP_Text textOperation;



    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //LISTEN TO EVENTS
        UI_RaindropsGame.ResultInput += HandleResultInput;

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



    //FUNCTIONALITIES
    private void SetVisibleContent(bool visible = true)
    {
        if(visible)
        {
            textNumberOne.text = myData.NumberOneValue.ToString();
            textNumberTwo.text = myData.NumberTwoValue.ToString();
            textOperation.text = TearOperationData.dictionaryEOP[myData.Operation];
        }
        else
        {
            textNumberOne.text = ">:y";
            textNumberTwo.text = "?";
            textOperation.text = ">:C";
        }
    }

    private void HandleMovement()
    {
        if(debugMode){
            if(debugSpeedDifficulty)
                transform.position = transform.position + (speedDiffCoeff * debugSpeed * Time.fixedDeltaTime * Vector3.down);
            else
                transform.position = transform.position + (debugSpeed * Time.fixedDeltaTime * Vector3.down);
        } else {
            transform.position = transform.position + (speedDiffCoeff * trueSpeed * Time.fixedDeltaTime * Vector3.down);
        }
    }



    //EVENT-FIRING METHOD
    private void OnTearSolved(TearEventArgs myEventArg) => TearSolved?.Invoke(this, myEventArg);

}
