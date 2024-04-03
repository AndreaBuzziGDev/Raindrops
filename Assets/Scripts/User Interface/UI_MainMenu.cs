using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    //DATA



    //GAMEOBJECT REFERENCES
    [SerializeField] SceneNavigationController snc;//TODO: MAKE IT A MONOSINGLETON?
    //TODO: ADD REFERENCES FOR PANEL STUFF
    


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //LISTEN EVENTS
        UI_RaindropsMainMenu.MainMenuEA += HandleMainMenuEvent;
    }
    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        UI_RaindropsMainMenu.MainMenuEA -= HandleMainMenuEvent;
    }
    

    //FUNCTIONALITIES
    ///GUI BUTTONS
    public void HandlePlay() => snc.LoadScene(SceneNavigationController.eSceneName.RaindropsGame);

    public void HandleOptions()
    {
        //...

    }

    public void HandleCredits() => snc.LoadScene(SceneNavigationController.eSceneName.Credits);

    public void HandleQuit() => UtilsGeneric.QuitGame();


    //EVENT HANDLING
    public void HandleMainMenuEvent(object sender, MainMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case MainMenuEventArgs.EType.MAIN_MENU:
                //TODO: IMPLEMENT
                break;
            default:
                //TODO: IMPLEMENT
                break;
        }
    }
}
