using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameStats : SaveData
{
    //
    protected int highScore;

    public int HighScore
    {
        get { return highScore; }
        set
        {
            if(value > 0)
                highScore = value;
            else
                highScore = 0;
        }
    }
}
