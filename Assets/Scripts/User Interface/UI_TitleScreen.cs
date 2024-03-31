using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitleScreen : MonoSingleton<UI_TitleScreen>
{
    //DATA



    //GAMEOBJECT REFERENCES
    [SerializeField] SceneNavigationController snc;


    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndChangeScene());
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    //FUNCTIONALITIES
    //TODO: JUICYNESS TO UI


    //COROUTINES
    IEnumerator WaitAndChangeScene()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        snc.LoadScene(SceneNavigationController.eSceneName.MainMenu);
    }

}
