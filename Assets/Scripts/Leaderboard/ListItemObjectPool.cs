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

    private List<RankingData> rankings;
    private int _loaded;

    private const float SHOW_ANIMATION_DELAY = 0.05f;
    private const float HIDE_ANIMATION_DELAY = 0.02f;

    public override void Init()
    {
        base.Init();
        _config.Init();
    }

    public void Load(LeaderboardData data)
    {
        _loaded = 0;
        rankings = new List<RankingData>(data.ranking);
        foreach (var r in rankings)
        {
            var dataUI = new PlayerDataUI(r, _config);
            pool.Get(out ListItem item);
            item.Init(dataUI);
        }
    }

    #region Pool implementation

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

    #endregion

    #region Animations
    public void Show()
    {
        StartCoroutine(ShowAnimation());
    }

    private IEnumerator ShowAnimation()
    {
        foreach (var i in activeObjects)
        {
            i.Show();
            yield return new WaitForSeconds(SHOW_ANIMATION_DELAY);
        }
    }

    public void Hide(Action onAnimationFinished)
    {
        StartCoroutine(HideAnimation(onAnimationFinished));
    }

    private IEnumerator HideAnimation(Action onAnimationFinished)
    {
        foreach (var i in activeObjects)
        {
            i.Hide();
            yield return new WaitForSeconds(HIDE_ANIMATION_DELAY);
        }
        base.ClearPool();
        onAnimationFinished?.Invoke();
    }
    #endregion
}
