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
    [SerializeField] SceneNavigationController SNC;






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
    //TODO: SWITCH THIS TO A PRIVATE IMPLEMENTATION ?
    //MIGHT PROVE AS AN INTERESTING EXERCISE IF USING AN EVENT-BASED IMPLEMENTATION. NOT NEEDED WITH SINGLETON.
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
                //TODO: IMPLEMENT UN-SHOWING PAUSE
                //SHOULD USE AN EVENT-BASED SYSTEM TO HANDLE SHOWING UI

                break;
            case EGameState.Paused:
                //TODO: IMPLEMENT SHOWING PAUSE
                //SHOULD USE AN EVENT-BASED SYSTEM TO HANDLE SHOWING UI

                break;
            case EGameState.GameOver:
                //TODO: IMPLEMENT SHOW UP OF GAME-OVER SCREEN

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
    //TODO: IMPLEMENT MISSING FUNCTIONALITIES



    //RESTART GAME
    private static void RestartGame() => Instance.SNC.LoadScene(SceneNavigationController.eSceneName.RaindropsGame);

    //QUIT GAME (ABANDON SESSION)
    private static void QuitGame() => Instance.SNC.LoadScene(SceneNavigationController.eSceneName.MainMenu);


    //EXIT GAME
    private static void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        #endif
    }




    //OTHER...
    

}
