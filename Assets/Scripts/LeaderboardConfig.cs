using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LeaderboardConfig", fileName = "LeaderboardConfig")]
public class LeaderboardConfig : ScriptableObject
{
    public List<Sprite> ranks = new List<Sprite>();
    public List<Sprite> characters = new List<Sprite>();
    public List<Sprite> flags = new List<Sprite>();
    public List<string> flagsKeys = new List<string>();

    private Dictionary<string, Sprite> _flagsData = new Dictionary<string, Sprite>();

    public void Init()
    {
        for (int i = 0; i < flags.Count; i++)
        {
            _flagsData.Add(flagsKeys[i], flags[i]);
        }
    }


    public Sprite GatFlag(string key)
    {
        return _flagsData[key];
    }

    public Sprite GetRankSprite(int rank)
    {
        return ranks.Count > rank - 1 ? ranks[rank - 1] : null;
    }
}
