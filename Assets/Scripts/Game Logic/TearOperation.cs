using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class TearOperation : MonoBehaviour
{
    //ENUMS
    public enum EOperation
    {
        SUM,
        DIFFERENCE,
        MULTIPLICATION,
        DIVISION
    }


    //DATA
    [SerializeField] private float tearSpeed = 1.0f;
    [SerializeField] private EOperation operation = EOperation.SUM;//TODO: THIS DOES NOT NEED TO BE A SERIALIZED FIELD AND SHOULD NOT BE.

    private float numberOneValue = 5;
    private float numberTwoValue = 4;


    private Dictionary<EOperation, string> dictionaryEOP = new Dictionary<EOperation, string>
    {
        {EOperation.SUM, "+"},
        {EOperation.DIFFERENCE, "-"},
        {EOperation.MULTIPLICATION, "x"},
        {EOperation.DIVISION, "/"}
    };





    //PREFAB REFERENCES
    [SerializeField] private TMP_Text textNumberOne;
    [SerializeField] private TMP_Text textNumberTwo;
    [SerializeField] private TMP_Text textOperation;




    //LIFECYCLE FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //SET POSITION TO STANDARD POSITION
        //TODO: MOVE TO APPROPRIATE POSITION
        
        //SETS THE VISUAL CONTENT OF THE PREFAB
        SetContent();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(0, -(tearSpeed * Time.fixedDeltaTime), 0);
    }




    //FUNCTIONALITIES
    private void SetContent()
    {
        textNumberOne.text = numberOneValue.ToString();
        textNumberTwo.text = numberTwoValue.ToString();
        textOperation.text = dictionaryEOP[operation];
    }


}
