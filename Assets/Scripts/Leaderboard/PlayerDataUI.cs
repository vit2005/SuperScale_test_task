using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerDataUI
{
    //[Inject] private LeaderboardConfig _config;

    public readonly Sprite rankSprite;
    public readonly int rank;
    public readonly Sprite character;
    public readonly Color characterColor;
    public readonly Sprite flag;
    public readonly string username;
    public readonly string points;
    public readonly bool isVip;

    public PlayerDataUI (RankingData data, LeaderboardConfig config)
    {
        Color color;
        if (!ColorUtility.TryParseHtmlString(data.player.characterColor, out color))
        {
            if (!ColorUtility.TryParseHtmlString("#" + data.player.characterColor, out color))
            {
                throw new System.InvalidCastException();
            }
        }

        this.rankSprite = config.GetRankSprite(data.ranking);
        this.rank = data.ranking;
        this.character = config.characters[data.player.characterIndex - 1];
        this.characterColor = color;
        this.flag = config.GatFlag(data.player.countryCode);
        this.username = data.player.username;
        this.points = string.Format("{0:# ###}", data.points);
        this.isVip = data.player.isVip;
    }
}
