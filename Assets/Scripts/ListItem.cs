using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ListItem : MonoBehaviour
{
    [SerializeField] private Image RankImage;
    [SerializeField] private TextMeshProUGUI RankText;
    [SerializeField] private Image Avatar;
    [SerializeField] private Image AvatarColor;
    [SerializeField] private Image CountryFlag;
    [SerializeField] private TextMeshProUGUI Username;
    [SerializeField] private TextMeshProUGUI Points;
    [SerializeField] private GameObject IsVip;

    [SerializeField] private GameObject Hover;
    private int _rank;
    public int Rank => _rank;

    private readonly Color invisible = new Color(0f, 0f, 0f, 0f);

    public void Init(Sprite rankSprite, int rank, Sprite character, Color characterColor, 
        Sprite flag, string username, int points, bool isVip)
    {
        _rank = rank;
        if (rankSprite != null)
        {
            RankImage.sprite = rankSprite;
        }
        else
        {
            RankImage.color = invisible;
        }
        
        RankText.text = rank.ToString();
        Avatar.sprite = character;
        AvatarColor.color = characterColor;
        CountryFlag.sprite = flag;
        Username.text = username;
        Points.text = string.Format("{0:# ###}", points);
        IsVip.SetActive(isVip);
    }

    public void Clear()
    {
        RankImage.color = Color.white;
        Username.text = "";
    }
}
