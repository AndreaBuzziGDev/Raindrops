using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_GameMenuPanel : MonoBehaviour
{
    //DATA


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //LISTEN EVENTS
        UI_RaindropsGame.GameMenuEA += HandleGameMenuEvent;
    }

    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        UI_RaindropsGame.GameMenuEA -= HandleGameMenuEvent;
    }



    //FUNCTIONALITIES
    ///GUI BUTTONS
    public void HandleContinue() => GameController.Instance.SetState(GameController.EGameState.Playing);

    public void HandleMainMenu() => GameController.Instance.SetState(GameController.EGameState.Quitting);

    public void HandleRestart() => GameController.Instance.SetState(GameController.EGameState.Restarting);

    public void HandleQuit() => GameController.Instance.SetState(GameController.EGameState.Exiting);


    //EVENT HANDLING
    public void HandleGameMenuEvent(object sender, GameMenuEventArgs e)
    {
        //OPEN
        if(e.EventType == GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN)
        {
            //
            this.gameObject.SetActive(true);
        }

        //CLOSE
        if(e.EventType == GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE)
        {
            //
            this.gameObject.SetActive(false);
        }
    }

}
