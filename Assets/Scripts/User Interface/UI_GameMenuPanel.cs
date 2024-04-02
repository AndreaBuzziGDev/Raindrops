using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class UI_GameMenuPanel : MonoBehaviour
{
    //DATA


    //GAMEOBJECT REFERENCES
    [SerializeField] CanvasRenderer buttonPanel;


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //DISABLE BUTTON PANEL
        buttonPanel.gameObject.SetActive(false);

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
        switch(e.EventType)
        {
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN:
                buttonPanel.gameObject.SetActive(true);
                break;
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE:
            case GameMenuEventArgs.EType.GAME_OVER:
                buttonPanel.gameObject.SetActive(false);
                break;
        }
    }

}
