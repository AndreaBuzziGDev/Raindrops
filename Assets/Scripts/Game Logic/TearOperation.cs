using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class TearOperation : MonoBehaviour
{
    //EVENTS
    public static event EventHandler<TearEventArgs> TearSolved;


    //DATA
    [SerializeField] private float tearSpeed = 1.0f;
    private TearOperationData myData;



    //PREFAB REFERENCES
    [SerializeField] private TMP_Text textNumberOne;
    [SerializeField] private TMP_Text textNumberTwo;
    [SerializeField] private TMP_Text textOperation;




    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //LISTEN TO EVENTS
        UI_RaindropsGame.ResultInput += HandleResultInput;

        //SET POSITION TO STANDARD POSITION
        transform.position = TearOperationSpawner.Instance.GetRandomPosition();

        //SETTING DATA
        TearOperationData.EOperation randomOp = TearOperationData.GetRandomOperation();
        myData = new TearOperationData(TearOperationData.GetRandomNumberOne(randomOp), TearOperationData.GetRandomNumberOne(randomOp), randomOp);
        
        //SETS THE VISUAL CONTENT OF THE PREFAB
        SetContent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO: A TEARCONTROLLER % BONUS MULTIPLIER
        transform.position = transform.position + tearSpeed * Time.fixedDeltaTime * Vector3.down;
    }

    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        UI_RaindropsGame.ResultInput -= HandleResultInput;
    }
    



    //EVENT HANDLING
    public void HandleResultInput(object sender, ResultInputEventArgs e)
    {
        //IF RESULT CORRECT = FIRE SOLUTION EVENT
        if(e.InputValue == this.myData.Result)
        {
            TearEventArgs myTearLostEvent = new(this, TearEventArgs.EType.SUCCESS);
            OnTearSolved(myTearLostEvent);
        }
    }




    //FUNCTIONALITIES
    private void SetContent()
    {
        textNumberOne.text = myData.NumberOneValue.ToString();
        textNumberTwo.text = myData.NumberTwoValue.ToString();
        textOperation.text = TearOperationData.dictionaryEOP[myData.Operation];
    }




    //EVENT-FIRING METHOD
    private void OnTearSolved(TearEventArgs myEventArg) => TearSolved?.Invoke(this, myEventArg);

}
