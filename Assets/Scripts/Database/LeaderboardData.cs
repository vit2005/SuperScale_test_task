using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[Serializable]
public class LeaderboardData
{
    public List<Ranking> ranking;
    public string playerUID;
}

[Serializable]
public class Ranking
{
    public Player player;
    public int ranking;
    public int points;
}

[Serializable]
public class Player
{
    public string uid;
    public string username;
    public bool isVip;
    public string countryCode;
    public string characterColor;
    public int characterIndex;
}
