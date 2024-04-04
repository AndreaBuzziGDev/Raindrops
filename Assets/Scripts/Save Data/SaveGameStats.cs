using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameStats : SaveData
{
    //DATA-ONLY CLASS...
    protected float highScore;

    public float HighScore
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
    
    //CONSTRUCTOR
    public SaveGameStats(string fileName, float highScore)
    {
        this.fileName = fileName;
        this.highScore = highScore;
    }
}
