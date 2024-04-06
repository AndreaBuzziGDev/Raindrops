using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighScoreEventArgs : EventArgs
{
    //DATA
    float newHighScore;
    public float NewHighScore { get { return newHighScore; } }

    //CONSTRUCTOR
    public HighScoreEventArgs (float newHighScore)
    {
        this.newHighScore = newHighScore;
    }
}
