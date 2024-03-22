using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UI_RaindropsGame : MonoBehaviour
{
    //EVENTS
    public static event EventHandler<ResultInputEventArgs> ResultInput;


    //DATA



    //PREFAB REFERENCES
    [SerializeField] private TMP_InputField inputField;





    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        inputField.text = "0";
    }





    //FUNCTIONALITIES





    //UI - BUTTON HANDLING
    public void HandleInputButton()
    {
        int.TryParse(inputField.text, out int testInt);//NB: INT WAS INLINE-DECLARED

        ResultInputEventArgs myResultInputEvent = new(testInt);
        OnTearLost(myResultInputEvent);

        //RESET TEXT FIELD
        inputField.text = "0";
    }





    //UTILITIES
    




    
    //EVENT-FIRING METHOD
    private void OnTearLost(ResultInputEventArgs myEventArg) => ResultInput?.Invoke(this, myEventArg);

}
