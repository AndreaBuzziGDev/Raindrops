using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class UtilsSave
{
    //FUNCTIONALITIES
    public void CreateSave(string savedFilePath, SaveData save)
    {
        if(!string.IsNullOrEmpty(savedFilePath))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Create(Application.persistentDataPath + "/" + savedFilePath + ".save");
            bf.Serialize(file, save);
            file.Close();
        }
        else
        {
            //TODO: THROW ERROR
            //
        }
    }
    public void LoadSave(string savedFilePath)
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/" + savedFilePath + ".save", FileMode.Open);

        }
    }

}
