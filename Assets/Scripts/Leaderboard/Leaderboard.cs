using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Leaderboard : MonoBehaviour
{
    [Inject] private IStorage storage;
    [SerializeField] private ListItemObjectPool poolController;
    [SerializeField] private Animator animator;

    public void Awake()
    {
        poolController.Init();
    }

    public void ShowLeaderboard()
    {
        if (gameObject.activeSelf) return;
        gameObject.SetActive(true);
        LeaderboardData data = storage.Load();
        poolController.Load(data);
        animator.SetTrigger("Show");
    }

    public void ShowPool()
    {
        poolController.Show();
    }

    public void HideLeaderboardClick()
    {
        poolController.Hide(DeactivateLeaderboard);
        animator.SetTrigger("Hide");
    }

    public void DeactivateLeaderboard()
    {
        gameObject.SetActive(false);
    }
}
