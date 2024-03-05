using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OfflineJSONStorage : IStorage
{
    private string fileLocation1 = Application.dataPath + "/Data/data7.json";
    private string fileLocation2 = Application.dataPath + "/Data/data10.json";
    private bool anotherData = false;

    public LeaderboardData Load()
    {
        string fileLocation = anotherData ? fileLocation1 : fileLocation2;
        anotherData = !anotherData;

        LeaderboardData database = new LeaderboardData();
        if (File.Exists(fileLocation))
        {
            string loadedFileString = File.ReadAllText(fileLocation);
            database = JsonUtility.FromJson<LeaderboardData>(loadedFileString);
        }
        else
        {
            Debug.LogError("Data file is missung");
        }

        return database;
    }
}
