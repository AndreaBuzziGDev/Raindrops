using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    //ENUMS
    public enum EGameState
    {
        Start,
        Playing,
        Paused,
        GameOver,
        Restarting,
        Quitting,
        Exiting
    }

    //DATA
    ///SIMPLE DATA
    private EGameState state = 0;
    public bool IsPaused { get { return this.state == EGameState.Paused; } }
    public bool IsGameOver { get { return this.state == EGameState.GameOver; } }
    public bool IsPlaying { get { return !(IsPaused || IsGameOver); } }


    //GAMEOBJECT REFERENCES




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameController is Starting.");

        //ENFORCES START SEQUENCE
        SetState(EGameState.Start);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
    //FUNCTIONALITIES
    public void SetState(EGameState targetState)
    {
        state = targetState;
        switch (state)
        {
            case EGameState.Start:
                //RESERVED FOR INITIALIZATION
                
                SetState(EGameState.Playing);
                break;
            case EGameState.Playing:
                GameMenuEventArgs gmea_c = new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE);
                UI_RaindropsGame.OnGamePause(this, gmea_c);
                break;
            case EGameState.Paused:
                GameMenuEventArgs gmea_o = new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN);
                UI_RaindropsGame.OnGamePause(this, gmea_o);
                break;
            case EGameState.GameOver:
                GameMenuEventArgs gmea_go = new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_OVER);
                UI_RaindropsGame.OnGamePause(this, gmea_go);
                break;
            case EGameState.Restarting:
                RestartGame();
                break;
            case EGameState.Quitting:
                QuitGame();
                break;
            case EGameState.Exiting:
                ExitGame();
                break;
        }
    }





    //STAGE-TRANSITION FUNCTIONALITIES

    //RESTART GAME
    private static void RestartGame() => SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.RaindropsGame);

    //QUIT GAME (ABANDON SESSION)
    private static void QuitGame() => SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.MainMenu);


    //EXIT GAME
    private static void ExitGame() => UtilsGeneric.QuitGame();




    //OTHER...
    

}
