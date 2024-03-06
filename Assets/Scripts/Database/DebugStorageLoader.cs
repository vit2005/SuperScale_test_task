using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DebugStorageLoader : MonoBehaviour
{
    [Inject] private IStorage storage;

    void Start()
    {
        LeaderboardData data = storage.Load();
        foreach (var item in data.ranking)
        {
            Debug.Log(item.player.username);
        }


        //Ranking ranking = new Ranking()
        //{
        //    player = new Player()
        //    {
        //        uid = "adfsdf",
        //        username = "sdfsdf",
        //        isVip = true,
        //        countryCode = "sd",
        //        characterColor = "#121212",
        //        characterIndex = 1,
        //    },
        //    ranking = 1,
        //    points = 1,
        //};

        //DataEntity root = new DataEntity()
        //{
        //    ranking = new List<Ranking>(),
        //    playerUID = "sdsd",
        //};
        //root.ranking.Add(ranking);
        //storage.Save(root);
    }
}
