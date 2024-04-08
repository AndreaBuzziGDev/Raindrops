using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UI_MainMenu : MonoBehaviour
{
    //DATA



    //GAMEOBJECT REFERENCES
    [SerializeField] Canvas mainMenuPanel;
    [SerializeField] private TMP_Text textHighScore;
    


    //LIFECYCLE FUNCTIONS
    void Awake()
    {
        //LISTEN EVENTS
        UI_RaindropsMainMenu.MainMenuEA += HandleMainMenuEvent;
        
        //INITIALIZE GAME SCORE
        SaveGameStats sgs = (SaveGameStats) UtilsSave.LoadSave(SaveController.defaultGameStatsName);
        textHighScore.text = (sgs==null ? 0 : sgs.HighScore).ToString();
    }
    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        UI_RaindropsMainMenu.MainMenuEA -= HandleMainMenuEvent;
    }
    

    //FUNCTIONALITIES
    ///GUI BUTTONS
    public void HandlePlay() => SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.RaindropsGame);

    public void HandleOptions() => UI_RaindropsMainMenu.OpenOptions();

    public void HandleCredits() => SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.Credits);

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
