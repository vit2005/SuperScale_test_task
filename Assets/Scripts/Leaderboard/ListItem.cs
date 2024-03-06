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

    [SerializeField] private Image Main;
    [SerializeField] private Image Hover;
    [SerializeField] private float animationSpeed;
    [SerializeField] private Animator animator;

    private bool isPointerEntered;

    private int _rank;
    public int Rank => _rank;

    public void Init(PlayerDataUI dataUI)
    {
        _rank = dataUI.rank;
        if (dataUI.rankSprite != null)
        {
            RankImage.sprite = dataUI.rankSprite;
        }
        else
        {
            RankImage.color = Color.clear;
        }
        
        RankText.text = dataUI.rank.ToString();
        Avatar.sprite = dataUI.character;
        AvatarColor.color = dataUI.characterColor;
        CountryFlag.sprite = dataUI.flag;
        Username.text = dataUI.username;
        Points.text = dataUI.points;
        IsVip.SetActive(dataUI.isVip);
    }

    public void Update()
    {
        EvaluateHoverAnimation();
    }

    private void EvaluateHoverAnimation()
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

    public void Show()
    {
        animator.SetTrigger("Show");
    }

    public void Hide()
    {
        animator.SetTrigger("Hide");
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
        Main.color = Color.clear;
        RankImage.color = Color.white;
        Hover.color = Color.clear;
        Username.text = "";
    }
}
