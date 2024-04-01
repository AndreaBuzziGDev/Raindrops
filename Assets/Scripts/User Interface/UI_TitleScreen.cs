using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_TitleScreen : MonoSingleton<UI_TitleScreen>
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

        //AUTO-LOAD NEXT SCENE
        StartCoroutine(WaitAndChangeScene());
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    void OnDestroy()
    {
        inputPlayer.BaseActionMap.Escape.performed -= OnEscapePerformed;
    }



    
    //FUNCTIONALITIES
    //TODO: JUICYNESS TO UI




    //INPUT EVENTS
    //EVENT-BASED INPUT IMPLEMENTATION
    private void OnEscapePerformed(InputAction.CallbackContext value)
    {
        snc.LoadScene(SceneNavigationController.eSceneName.MainMenu);
    }


    //COROUTINES
    IEnumerator WaitAndChangeScene()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        snc.LoadScene(SceneNavigationController.eSceneName.MainMenu);
    }

}
