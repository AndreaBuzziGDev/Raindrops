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
    public ETearType TearType { get { return tearType; } }
    
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




    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //LISTEN TO EVENTS
        UI_RaindropsGame.ResultInput += HandleResultInput;
        UI_RaindropsGame.GameMenuEA += HandleGameMenuEvent;

        //LISTENS TO OWN-EVENT FOR HANDLING GOLDEN SOLUTIONS
        TearSolved += HandleGoldenSolution;

        //SETTING DATA
        TearOperationData.EOperation randomOp = TearOperationData.GetRandomOperation();
        if(debugMode)
            myData = new TearOperationData(debugValueTop, debugValueBottom, debugOperation);
        else
            myData = new TearOperationData(TearOperationData.GetRandomNumberOne(randomOp), TearOperationData.GetRandomNumberTwo(randomOp), randomOp);
        
        //DIFFICULTY SETTING
        speedDiffCoeff = TearController.Instance.SpeedDifficultyValue;

        //SETS THE VISUAL CONTENT OF THE PREFAB
        SetVisibleContent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameController.Instance.IsPlaying) 
            HandleMovement();
    }

    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        UI_RaindropsGame.ResultInput -= HandleResultInput;
        UI_RaindropsGame.GameMenuEA -= HandleGameMenuEvent;
        TearSolved -= HandleGoldenSolution;
    }



    //EVENT HANDLING
    private void HandleResultInput(object sender, ResultInputEventArgs e)
    {
        //IF RESULT CORRECT = FIRE SOLUTION EVENT
        if(e.InputValue == this.myData.Result)
        {
            TearEventArgs myTearLostEvent = new(this, TearEventArgs.EType.SUCCESS);
            OnTearSolved(myTearLostEvent);
        }
    }

    private void HandleGameMenuEvent(object sender, GameMenuEventArgs e)
    {
        if(e.EventType == GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN)
            SetVisibleContent(false);
        else
            SetVisibleContent();
    }

    public void HandleGoldenSolution(object sender, TearEventArgs e)
    {
        //GOLD TEARS DON'T EXPLODE FOR GOLD TEARS
        if(tearType != ETearType.GOLD && e.AffectedTear.tearType == ETearType.GOLD)
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
