using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameMenuPanel : MonoBehaviour
{
    //DATA


    //METHODS
    public void HandleContinue()
    {
        //TODO: REMOVE MENU
        //SHOULD USE AN EVENT-BASED SYSTEM TO HANDLE SHOWING UI

        //UNPAUSE
        GameController.Instance.SetState(GameController.EGameState.Playing);
    }

    public void HandleMainMenu()
    {
        GameController.Instance.SetState(GameController.EGameState.Quitting);
        
    }

    public void HandleRestart()
    {
        //TODO: RELOAD THE GAMEPLAY SCENE
        
    }

    public void HandleQuit()
    {
        //TODO: QUIT APPLICATION
        GameController.Instance.SetState(GameController.EGameState.Exiting);
        
    }
}
