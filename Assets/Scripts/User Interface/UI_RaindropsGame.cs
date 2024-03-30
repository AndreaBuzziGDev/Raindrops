using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class UI_RaindropsGame : MonoBehaviour
{
    //EVENTS
    public static event EventHandler<ResultInputEventArgs> ResultInput;


    //DATA
    ///INPUT - EVENT-DRIVEN IMPLEMENTATION
    private RaindropsAction inputPlayer = null;
    public RaindropsAction InputPlayer { get { return inputPlayer; } }




    //PREFAB REFERENCES
    [SerializeField] private TMP_InputField inputField;





    //LIFECYCLE FUNCTIONS
    private void Awake()
    {
        inputPlayer = new RaindropsAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputField.text = "0";
    }

    private void OnEnable()
    {
        //ENABLE INPUT WHEN OBJECT ENABLED
        inputPlayer.Enable();

        //ACTION SUBSCRIPTIONS
        //ENTER
        inputPlayer.BaseActionMap.EnterAction.performed += OnEnterPerformed;
        //ESCAPE
        inputPlayer.BaseActionMap.EnterAction.performed += OnEscapePerformed;

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
        //TODO: OPEN MENU AND/OR HANDLE ESC
    }


    //UI - BUTTON HANDLING
    public void HandleInputButton() => DoBroadcastResult();
    
    






    //UTILITIES
    




    
    //EVENT-FIRING METHOD
    private void OnTearLost(ResultInputEventArgs myEventArg) => ResultInput?.Invoke(this, myEventArg);

}
