using System.Collections;
using System.Collections.Generic;
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
        Quitting,
        Exiting
    }

    //DATA
    ///SIMPLE DATA
    private EGameState state = 0;
    public bool IsPaused { get { return this.state == EGameState.Paused; } }
    public bool IsGameOver { get { return this.state == EGameState.GameOver; } }






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
    //TODO: SWITCH THIS TO A PRIVATE IMPLEMENTATION
    public void SetState(EGameState targetState)
    {
        state = targetState;
        switch (state)
        {
            case EGameState.Start:
                //RESERVED FOR INITIALIZATION
                //TODO: IMPLEMENT
                SetState(EGameState.Playing);
                break;

            case EGameState.Playing:
                //TODO: IMPLEMENT

                break;

            case EGameState.Paused:
                //TODO: IMPLEMENT

                break;

            case EGameState.GameOver:
                //TODO: IMPLEMENT

                break;

            case EGameState.Quitting:
                //TODO: IMPLEMENT

                break;

            case EGameState.Exiting:
                //TODO: IMPLEMENT

                break;

        }
    }





    //STAGE-TRANSITION FUNCTIONALITIES
    //TODO: IMPLEMENT MISSING FUNCTIONALITIES



    //QUIT GAME (ABANDON SESSION)
    private static void QuitGame()
    {
        //TODO: GO BACK TO MAIN MENU
        
    }


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
