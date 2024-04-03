using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class UI_RaindropsMainMenu : MonoSingleton<UI_RaindropsMainMenu>
{
    //EVENTS
    public static event EventHandler<MainMenuEventArgs> MainMenuEA;


    //DATA
    ///INPUT - EVENT-DRIVEN IMPLEMENTATION
    private RaindropsAction inputPlayer = null;
    public RaindropsAction InputPlayer { get { return inputPlayer; } }


    //PREFAB REFERENCES


    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        OnMainMenuEA(this, new());
    }

    private void OnEnable()
    {
        //ENABLE INPUT WHEN OBJECT STARTS
        inputPlayer = new RaindropsAction();
        inputPlayer.Enable();

        //ACTION SUBSCRIPTIONS
        //ESCAPE
        inputPlayer.BaseActionMap.Escape.performed += OnEscapePerformed;
    }




    //INPUT EVENTS
    //EVENT-BASED INPUT IMPLEMENTATION
    private void OnEscapePerformed(InputAction.CallbackContext value) => MainMenuEA?.Invoke(this, new());

    //FUNCTIONALITIES
    public void OpenMainMenu() => MainMenuEA?.Invoke(this, new(MainMenuEventArgs.EType.MAIN_MENU));
    public void OpenOptions() => MainMenuEA?.Invoke(this, new(MainMenuEventArgs.EType.MAIN_OPTIONS));



    //UTILITIES

    
    //EVENT-FIRING METHOD
    public static void OnMainMenuEA(object sender, MainMenuEventArgs myEventArg) => MainMenuEA?.Invoke(sender, myEventArg);

}
