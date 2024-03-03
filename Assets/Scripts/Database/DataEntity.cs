using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataEntity
{
    public List<SingleRankData> ranking;
}

public class SingleRankData
{
    public PlayerData player;
    public int ranking;
    public int points;
}

public class PlayerData
{
    public GUID uid;
    public string username;
    public bool isVip;
    public string countryCode;
    public string characterColor;
    public int characterIndex;
}
