﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoCard : MonoBehaviour
{
    [SerializeField] private Canvas m_canvas;

    [SerializeField] private Button m_backButton;

    [SerializeField] private TMP_Text m_nameText;
    [SerializeField] private TMP_Text m_infoText;

    [SerializeField] private Image m_objectImage;
    [SerializeField] private Image m_categoryImage;
    [SerializeField] private Image m_rarityImage;

    public void Enable()
    {
        m_canvas.enabled = true;
    }
    public void Disable()
    {
        m_canvas.enabled = false;
    }

    public void Initialize()
    {
        Disable();
        m_backButton.onClick.AddListener(Disable);
    }

    public void SetInfo(MapObjectCard card_)
    {
        m_nameText.text = card_.SO.Name;
        m_infoText.text = card_.SO.Info;
        m_objectImage.sprite = card_.SO.TitleImage;
        m_categoryImage.sprite = card_.SO.Category.Image;
        m_rarityImage.sprite = card_.SO.Rarity.Icon;
    }
}