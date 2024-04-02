using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //DATA-ONLY CLASS...
    protected string fileName;
    
    //DATA GETTERS
    public string FileName
    {
        get { return fileName; } 
        set 
        { 
            if(value != null && !string.IsNullOrEmpty(value))
                fileName = value;
        }
    }

}
