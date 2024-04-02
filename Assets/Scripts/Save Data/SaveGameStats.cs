using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameStats : SaveData
{
    //DATA-ONLY CLASS...
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
    
    //CONSTRUCTOR
    public SaveGameStats(string fileName, int highScore)
    {
        this.fileName = fileName;
        this.highScore = highScore;
    }
}
