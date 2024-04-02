using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: DELETE. This controller has become completely obsolete. using UI_MainMenu Instead.
public class MenuNavigationController : MonoBehaviour
{
    //ENUMS
    public enum eMainMenuCanvas
    {
        Main,
        Options,
        Quit
    }
    
    
    
    //DATA
    [SerializeField] private Canvas MainMenuCanvas;
    [SerializeField] private Canvas OptionsCanvas;
    
    ///ALL THE CANVAS HERE
    private List<Canvas> allCanvas = new();
    
    ///LAST TARGET CANVAS
    private eMainMenuCanvas lastTargetCanvas = 0;
    
    
    //LIFECYCLE FUNCTIONS
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeGUI();
    }
    
    
    
    
    
    //FUNCTIONALITIES
    
    //HANDLING SPECIFIC CANVAS
    public void SetTargetCanvas(eMainMenuCanvas targetCanvas)
    {
        //EXIT GAME
        if (targetCanvas == eMainMenuCanvas.Quit) ExitGame();
        else DisableAllCanvas();

        //SWITCH
        switch (targetCanvas)
        {
            case eMainMenuCanvas.Main:
                //MAIN MENU
                MainMenuCanvas.gameObject.SetActive(true);
                break;
            case eMainMenuCanvas.Options:
                //OPTIONS
                OptionsCanvas.gameObject.SetActive(true);
                break;
            default:
                //DEFAULT -> MAIN MENU
                MainMenuCanvas.gameObject.SetActive(true);
                break;
        }

        lastTargetCanvas = targetCanvas;
    }


    private void DisableAllCanvas() 
    {
        foreach (Canvas c in allCanvas) c.gameObject.SetActive(false);
    }






    //INITIALIZATION
    private void InitializeGUI()
    {
        BuildAllCanvas();
        SetTargetCanvas(lastTargetCanvas);
    }

    private void BuildAllCanvas()
    {
        allCanvas = new List<Canvas> { 
            MainMenuCanvas,
            OptionsCanvas
        };
    }





    //UTILITES

    ///CHECKS IF THIS IS THE ACTIVE CANVAS
    public bool isActiveCanvas(eMainMenuCanvas canvasChecked) => canvasChecked == lastTargetCanvas;
    
    
    ///EXIT GAME
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
}
