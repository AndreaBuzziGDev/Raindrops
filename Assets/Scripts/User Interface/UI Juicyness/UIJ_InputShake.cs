using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UIJ_InputShake : MonoBehaviour
{
    //DATA
    Vector3 initialPositionUI;
    
    //CONFIGURATIONS
    [SerializeField] float shakeDurationMax = 0.35f;
    [SerializeField] float shakeHeight = 5.0f;
    [SerializeField] float shakeSpeed = 50.0f;
    float shakeDuration = 0.0f;
    
    //COROUTINE REFERENCE
    IEnumerator shakeCoroutine;




    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //
        initialPositionUI = transform.position;

        //LISTEN EVENTS
        UI_RaindropsGame.ResultInput += HandleGameMenuEvent;
    }

    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        UI_RaindropsGame.ResultInput -= HandleGameMenuEvent;
    }


    //EVENT HANDLING
    private void HandleGameMenuEvent(object sender, ResultInputEventArgs e)
    {
        //TODO: START COROUTINE
        Debug.Log("Test Coroutine");
        shakeDuration = shakeDurationMax;
        shakeCoroutine = ShakeUI();
        StartCoroutine(shakeCoroutine);
    }

    //COROUTINES
    IEnumerator ShakeUI()
    {
        
        Debug.Log("ShakeUI Coroutine - shakeDuration Before: " + shakeDuration);
        //TODO: HANDLE SHAKE AMOUNT AND WIDTH
        for(float myDuration = shakeDurationMax; myDuration >= 0; myDuration -= Time.unscaledDeltaTime)
        {
            Debug.Log("ShakeUI Coroutine - shakeDuration During: " + myDuration);
            transform.position = initialPositionUI + new Vector3(0, shakeHeight * math.cos(Time.unscaledTime * shakeSpeed), 0);
            yield return null;
        }
        transform.position = initialPositionUI;
        Debug.Log("ShakeUI Coroutine - shakeDuration After: " + shakeDuration);
    }
    
    /*
    IEnumerator Fade()
    {
        Color c = renderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return null;
        }
    }
    */

}
