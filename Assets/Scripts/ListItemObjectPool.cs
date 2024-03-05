using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ListItemObjectPool : MonoBehaviorObjectPool<ListItem>
{
    [SerializeField] private ListItem _prefab;
    [SerializeField] private LeaderboardConfig _config;

    public override ListItem prefab => _prefab;
    public override Transform parent => transform;

    private List<Ranking> rankings;
    private int _loaded;

    public override void Init()
    {
        base.Init();
        _config.Init();
    }

    public void Show(LeaderboardData data)
    {
        _loaded = 0;
        rankings = new List<Ranking>(data.ranking);
        foreach (var r in rankings)
        {
            pool.Get(out ListItem item);
            Color color;
            if (!UnityEngine.ColorUtility.TryParseHtmlString(r.player.characterColor, out color))
            {
                if (!UnityEngine.ColorUtility.TryParseHtmlString("#" + r.player.characterColor, out color))
                {
                    Debug.LogError("Invalid color data");
                    continue;
                }
            }
                    
            item.Init(_config.GetRankSprite(r.ranking), r.ranking, _config.characters[r.player.characterIndex-1], color,
                _config.GatFlag(r.player.countryCode), r.player.username, r.points, r.player.isVip);
        }
    }

    protected override void OnTakeFromPool(ListItem item)
    {
        base.OnTakeFromPool(item);
        _loaded++;
        if (_loaded == rankings.Count) SortAfterAllLoaded();
    }

    private void SortAfterAllLoaded()
    {
        activeObjects.OrderBy(x => x.Rank);
        foreach (var o in activeObjects) { 
            o.transform.SetAsLastSibling(); 
        }
    }

    protected override void OnReturnedToPool(ListItem item)
    {
        base.OnReturnedToPool(item);
        item.Clear();
    }

    public void Hide()
    {
        base.ClearPool();
    }
}
