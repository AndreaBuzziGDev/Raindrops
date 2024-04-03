using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    //DATA



    //GAMEOBJECT REFERENCES
    [SerializeField] SceneNavigationController snc;//TODO: MAKE IT A MONOSINGLETON?
    [SerializeField] Canvas mainMenuPanel;
    


    //LIFECYCLE FUNCTIONS
    void Awake()
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
        //TODO: MAKE OPTIONS TRANSITION TO THE RIGHT MENU
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
                mainMenuPanel.gameObject.SetActive(true);
                break;
            default:
                mainMenuPanel.gameObject.SetActive(false);
                break;
        }
    }
}
