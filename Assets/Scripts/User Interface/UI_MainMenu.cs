using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    //DATA



    //GAMEOBJECT REFERENCES
    [SerializeField] SceneNavigationController snc;//TODO: MAKE IT A MONOSINGLETON?
    


    //LIFECYCLE FUNCTIONS
    

    //FUNCTIONALITIES
    ///GUI BUTTONS
    public void HandlePlay() => snc.LoadScene(SceneNavigationController.eSceneName.RaindropsGame);

    public void HandleOptions()
    {
        //...

    }

    public void HandleCredits() => snc.LoadScene(SceneNavigationController.eSceneName.Credits);

    public void HandleQuit() => UtilsGeneric.QuitGame();


}
