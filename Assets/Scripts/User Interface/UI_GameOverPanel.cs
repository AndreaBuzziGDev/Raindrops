using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOverPanel : MonoBehaviour
{
    //DATA


    //GAMEOBJECT REFERENCES
    [SerializeField] CanvasRenderer gameOverCanvas;//TODO: USE TO ADDRESS VISIBILITY


    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //DISABLE CANVAS
        gameOverCanvas.gameObject.SetActive(false);
        
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
    //TODO: IMPLEMENT ACTUAL GUI
    

    //EVENT HANDLING
    public void HandleGameMenuEvent(object sender, GameMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN:
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE:
                gameOverCanvas.gameObject.SetActive(false);
                break;
            case GameMenuEventArgs.EType.GAME_OVER:
                gameOverCanvas.gameObject.SetActive(true);
                break;
        }
    }
}
