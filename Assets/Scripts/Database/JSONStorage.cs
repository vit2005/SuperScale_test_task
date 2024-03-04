using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONStorage : IStorage
{
    string fileLocation = Application.dataPath + "/Data/data10.json";

    public DataEntity Load()
    {
        DataEntity database = new DataEntity();
        if (File.Exists(fileLocation))
        {
            //File.Delete(fileLocation);
            string loadedFileString = File.ReadAllText(fileLocation);
            database = JsonUtility.FromJson<DataEntity>(loadedFileString);
        }
        else
        {
            Save(database);
        }

        return database;
    }

    public void Save(DataEntity database)
    {
        string s = JsonUtility.ToJson(database);
        File.WriteAllText(fileLocation, s);
    }
}
