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

    [SerializeField] private Image Hover;
    [SerializeField] private float animationSpeed;

    private float animationStartTime = 0f;
    private bool isPointerEntered;

    private int _rank;
    public int Rank => _rank;

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
            RankImage.color = Color.clear;
        }
        
        RankText.text = rank.ToString();
        Avatar.sprite = character;
        AvatarColor.color = characterColor;
        CountryFlag.sprite = flag;
        Username.text = username;
        Points.text = string.Format("{0:# ###}", points);
        IsVip.SetActive(isVip);
    }

    public void Update()
    {
        EvaluateAnimation();
    }

    private void EvaluateAnimation()
    {
        float opacity = Hover.color.a;
        if (isPointerEntered && opacity < 1f)
        {
            opacity += Time.deltaTime * animationSpeed;
            opacity = Mathf.Clamp01(opacity);
            Hover.color = new Color(1f, 1f, 1f, opacity);
        }
        else if (!isPointerEntered && opacity > 0f)
        {
            opacity -= Time.deltaTime * animationSpeed;
            opacity = Mathf.Clamp01(opacity);
            Hover.color = new Color(1f, 1f, 1f, opacity);
        }
    }

    public void OnPointerEnter()
    {
        isPointerEntered = true;
    }

    public void OnPointerExit()
    {
        isPointerEntered = false;
    }

    public void Clear()
    {
        RankImage.color = Color.white;
        Hover.color = Color.clear;
        Username.text = "";
    }
}
