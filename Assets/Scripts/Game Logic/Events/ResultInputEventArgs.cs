using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResultInputEventArgs : EventArgs
{
    //DATA
    private int inputValue = 0;
    public int InputValue { get { return inputValue; } }

    //CONSTRUCTOR
    public ResultInputEventArgs (int inputValue)
    {
        this.inputValue = inputValue;
    }

}
