using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class UtilsSave
{
    //FUNCTIONALITIES
    public static void CreateSave(string savedFilePath, SaveData save)
    {
        if(string.IsNullOrEmpty(savedFilePath))
            throw new ArgumentException(String.Format("{0} is null or empty.", savedFilePath), "savedFilePath");
        else if(save == null)
            throw new ArgumentException(String.Format("{0} is null.", save), "save");
        else
        {
            BinaryFormatter bf = new();
            FileStream file = File.Create(Application.persistentDataPath + "/" + savedFilePath + ".save");
            bf.Serialize(file, save);
            file.Close();
        }
    }

    public static SaveData LoadSave(string savedFilePath)
    {
        if (File.Exists(Application.persistentDataPath + "/" + savedFilePath + ".save"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/" + savedFilePath + ".save", FileMode.Open);
            SaveData save = (SaveData) bf.Deserialize(file);
            file.Close();

            return save;
        }
        else
        {
            Debug.Log("File Does not exist: " + savedFilePath);
            return null;
        }
    }
}
