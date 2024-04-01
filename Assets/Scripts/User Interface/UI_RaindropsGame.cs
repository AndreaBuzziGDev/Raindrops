using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class UI_RaindropsGame : MonoSingleton<UI_RaindropsGame>
{
    //EVENTS
    public static event EventHandler<ResultInputEventArgs> ResultInput;
    public static event EventHandler<GameMenuEventArgs> GameMenuEA;


    //DATA
    ///INPUT - EVENT-DRIVEN IMPLEMENTATION
    private RaindropsAction inputPlayer = null;
    public RaindropsAction InputPlayer { get { return inputPlayer; } }




    //PREFAB REFERENCES
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text textScore;





    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        inputPlayer = new RaindropsAction();

        inputField.text = "0";
        textScore.text = "0";
    }

    private void OnEnable()
    {
        //ENABLE INPUT WHEN OBJECT ENABLED
        inputPlayer.Enable();

        //ACTION SUBSCRIPTIONS
        //ENTER
        inputPlayer.BaseActionMap.EnterAction.performed += OnEnterPerformed;
        //ESCAPE
        inputPlayer.BaseActionMap.Escape.performed += OnEscapePerformed;

    }

    private void OnDisable()
    {
        //ACTION UN-SUBSCRIPTIONS
        //ENTER
        inputPlayer.BaseActionMap.EnterAction.performed -= OnEnterPerformed;
        //ESCAPE
        inputPlayer.BaseActionMap.EnterAction.performed -= OnEscapePerformed;

        //DISABLE INPUT WHEN OBJECT DISABLED
        inputPlayer.Disable();
    }




    //FUNCTIONALITIES
    private void DoBroadcastResult()
    {
        int.TryParse(inputField.text, out int testInt);//NB: INT WAS INLINE-DECLARED

        ResultInputEventArgs myResultInputEvent = new(testInt);
        OnTearLost(myResultInputEvent);

        //RESET TEXT FIELD
        inputField.text = "0";

        //FOCUS INPUT FIELD
        inputField.Select();
        inputField.ActivateInputField();
    }




    //INPUT EVENTS
    //EVENT-BASED INPUT IMPLEMENTATION
    private void OnEnterPerformed(InputAction.CallbackContext value)
    {
        if(GameController.Instance.IsPlaying)
            DoBroadcastResult();
        //TODO: RE-FOCUS CURSOR ON INPUT FIELD
    }

    private void OnEscapePerformed(InputAction.CallbackContext value)
    {
        if(GameController.Instance.IsPlaying)
            GameController.Instance.SetState(GameController.EGameState.Paused);
        else
            GameController.Instance.SetState(GameController.EGameState.Playing);
    }


    //UI - BUTTON HANDLING
    public void HandleInputButton() => DoBroadcastResult();
    
    






    //UTILITIES
    public void SetScore(int newScore) => textScore.text = newScore.ToString();




    
    //EVENT-FIRING METHOD
    private void OnTearLost(ResultInputEventArgs myEventArg) => ResultInput?.Invoke(this, myEventArg);
    
    public static void OnGamePause(object sender, GameMenuEventArgs myEventArg) => GameMenuEA?.Invoke(sender, myEventArg);

}
