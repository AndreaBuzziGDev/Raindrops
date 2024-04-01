using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Credits : MonoBehaviour
{
    //DATA
    ///INPUT - EVENT-DRIVEN IMPLEMENTATION
    private RaindropsAction inputPlayer = null;
    public RaindropsAction InputPlayer { get { return inputPlayer; } }



    //GAMEOBJECT REFERENCES
    [SerializeField] SceneNavigationController snc;


    //LIFECYCLE FUNCTIONS
    
    // Start is called before the first frame update
    void Start()
    {
        //ENABLE INPUT WHEN OBJECT ENABLED
        inputPlayer = new RaindropsAction();
        inputPlayer.Enable();

        //ACTION SUBSCRIPTIONS
        //ESCAPE
        inputPlayer.BaseActionMap.Escape.performed += OnEscapePerformed;
    }

    void OnDestroy()
    {
        inputPlayer.BaseActionMap.Escape.performed -= OnEscapePerformed;
    }




    //FUNCTIONALITIES
    public void HandleBack() => snc.LoadScene(SceneNavigationController.eSceneName.MainMenu);




    //INPUT EVENTS
    //EVENT-BASED INPUT IMPLEMENTATION
    private void OnEscapePerformed(InputAction.CallbackContext value)
    {
        snc.LoadScene(SceneNavigationController.eSceneName.MainMenu);
    }

}
