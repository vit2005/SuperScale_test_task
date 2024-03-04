using System.Collections;
using System.Collections.Generic;
using TMPro;
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
}
