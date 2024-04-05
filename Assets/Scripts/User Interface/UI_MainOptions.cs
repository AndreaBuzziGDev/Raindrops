using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//NB: THIS SCRIPT (AS WELL AS UI_MainMenu) CAN BE REFACTORED WITH A COMMON PARENT TO ALLOW CONFIGURATION TO BE MUCH MORE ADAPTABLE AND SIMPLIFIED
public class UI_MainOptions : MonoBehaviour
{
    //DATA



    //GAMEOBJECT REFERENCES
    [SerializeField] Canvas optionsMenuPanel;

    [SerializeField] TMP_Dropdown difficultyDropDown;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider soundFXVolumeSlider;

    
    

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
    private void RefreshView()
    {
        //PRE-LOADING VALUES
        difficultyDropDown.value = UtilsPrefs.GameSettings.GetGameSpeed();

        musicVolumeSlider.value = UtilsPrefs.Options.GetVolumeMusic();
        soundFXVolumeSlider.value = UtilsPrefs.Options.GetVolumeEffects();
    }


    //UI ELEMENTS
    //DROPDOWN MENUS
    public void HandleDifficultyChange(int newValue) => UtilsPrefs.GameSettings.SetGameSpeed((UtilsPrefs.GameSettings.DIFFICULTY) newValue);


    //SLIDERS
    public void HandleVolumeMusicChange() => UtilsPrefs.Options.SetVolumeMusic(musicVolumeSlider.value);
    public void HandleVolumeSoundFXChange() => UtilsPrefs.Options.SetVolumeEffects(soundFXVolumeSlider.value);


    //BUTTONS
    public void OpenMainMenu() => UI_RaindropsMainMenu.OpenMainMenu();


    //EVENT HANDLING
    public void HandleMainMenuEvent(object sender, MainMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case MainMenuEventArgs.EType.MAIN_OPTIONS:
                optionsMenuPanel.gameObject.SetActive(true);
                RefreshView();
                break;
            default:
                optionsMenuPanel.gameObject.SetActive(false);
                break;
        }
    }
}
