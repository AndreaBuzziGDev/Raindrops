using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NB: THIS SCRIPT (AS WELL AS UI_MainMenu) CAN BE REFACTORED WITH A COMMON PARENT TO ALLOW CONFIGURATION TO BE MUCH MORE ADAPTABLE AND SIMPLIFIED
public class UI_MainOptions : MonoBehaviour
{
    //DATA



    //GAMEOBJECT REFERENCES
    [SerializeField] Canvas optionsMenuPanel;
    
    

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
    

    //EVENT HANDLING
    public void HandleMainMenuEvent(object sender, MainMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case MainMenuEventArgs.EType.MAIN_MENU:
                optionsMenuPanel.gameObject.SetActive(true);
                break;
            default:
                optionsMenuPanel.gameObject.SetActive(false);
                break;
        }
    }
}
