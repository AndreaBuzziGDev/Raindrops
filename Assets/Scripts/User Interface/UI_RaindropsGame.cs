using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
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
    [Header("UI Parametrization")]
    [SerializeField] Color highScoreColor = new (255, 215, 0);

    [Header("UI Items References")]
    [SerializeField] private Image scorePanelImage;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private TMP_Text textLives;





    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        inputField.text = "0";
        inputField.Select();
        inputField.ActivateInputField();
    }

    private void OnEnable()
    {
        //ENABLE INPUT WHEN OBJECT ENABLED
        inputPlayer = new RaindropsAction();
        inputPlayer.Enable();

        //ACTION SUBSCRIPTIONS
        //ENTER
        inputPlayer.BaseActionMap.EnterAction.performed += OnEnterPerformed;
        //ESCAPE
        inputPlayer.BaseActionMap.Escape.performed += OnEscapePerformed;

        //NEW HIGHSCORE
        TearController.OnNewHighScore += HandleNewHighScore;
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

        //NEW HIGHSCORE
        TearController.OnNewHighScore -= HandleNewHighScore;
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
    }

    private void OnEscapePerformed(InputAction.CallbackContext value)
    {
        if(GameController.Instance.IsPlaying)
            GameController.Instance.SetState(GameController.EGameState.Paused);
        else if(!GameController.Instance.IsGameOver)
            GameController.Instance.SetState(GameController.EGameState.Playing);
    }

    //HIGHSCORE
    private void HandleNewHighScore(object sender, HighScoreEventArgs e) => scorePanelImage.color = highScoreColor;




    //UI - BUTTON HANDLING
    public void HandleInputButton() => DoBroadcastResult();
    
    






    //UTILITIES
    public void SetScore(float newScore) => textScore.text = newScore.ToString();
    public void SetLives(int newLives) => textLives.text = newLives.ToString();




    
    //EVENT-FIRING METHOD
    private void OnTearLost(ResultInputEventArgs myEventArg) => ResultInput?.Invoke(this, myEventArg);
    
    //NB: USAGE OF THIS OUTSIDE OF THIS CLASS IS NOT NECESSARILY GOOD PRACTICE
    public static void OnGamePause(object sender, GameMenuEventArgs myEventArg) => GameMenuEA?.Invoke(sender, myEventArg);

}
