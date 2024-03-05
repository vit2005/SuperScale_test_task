using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Leaderboard : MonoBehaviour
{
    [Inject] private IStorage storage;
    [SerializeField] private ListItemObjectPool poolController;

    public void Awake()
    {
        poolController.Init();
    }

    public void ShowLeaderboard()
    {
        if (gameObject.activeSelf) return;
        gameObject.SetActive(true);
        LeaderboardData data = storage.Load();
        poolController.Show(data);
    }

    public void HideLeaderboard()
    {
        poolController.Hide();
        gameObject.SetActive(false);
    }
}
