using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameMenuPanel : MonoBehaviour
{
    //DATA


    //METHODS
    public void HandleContinue() => GameController.Instance.SetState(GameController.EGameState.Playing);

    public void HandleMainMenu() => GameController.Instance.SetState(GameController.EGameState.Quitting);

    public void HandleRestart() => GameController.Instance.SetState(GameController.EGameState.Restarting);

    public void HandleQuit() => GameController.Instance.SetState(GameController.EGameState.Exiting);
}
