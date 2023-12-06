﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    const int
        m_DeckSize = 10,
        m_HandSize = 4,
        m_DrawSize = 2;

    [SerializeField] private CardGenerator m_cardGenerator;

    public MapObjectCard GetSelectCard { get
        { return m_ToggleGroup.ActiveToggles().FirstOrDefault()?.GetComponent<MapObjectCard>(); }
    }

    [SerializeField] List<int> m_Deck = new(m_DeckSize);

    [SerializeField] ToggleGroup m_ToggleGroup;

    private const float CardSelectOffset = 50.0f;

    public List<int> TrashCardList = new();
    public List<int> HandCardList = new();
    public List<int> StockCardList = new();

    public void Initialize()
    {
        for (int i = 0; i < m_HandSize; ++i)
        {
            var _index = Random.Range(0, m_Deck.Count - 1);
            _index = 10 + i;
            Debug.Log(_index);
            Debug.Log(m_Deck[_index]);
            HandCardList.Add(m_Deck[_index]);

            CardCreate(_index);

            m_Deck.RemoveAt(_index);
        }
        StockCardList = new(m_Deck);
        m_Deck.Clear();
    }

    private void CardCreate(int index_)
    {
        var _moc = m_cardGenerator.Create(index_, transform);

        var _toggle = _moc.gameObject.GetComponent<Toggle>();
        _toggle.group = m_ToggleGroup;

        _moc.Event_Trash += () =>
        {
            TrashCardList.Add(index_);
            HandCardList.Remove(index_);
        };

        var _rect = _moc.transform as RectTransform;
        _rect.localScale = Vector2.one * 0.5f;

        _toggle.onValueChanged.AddListener((bool isOn_) =>
        {
            _rect.anchoredPosition = new Vector2(
                _rect.anchoredPosition.x,
                isOn_ ?
                _rect.anchoredPosition.y + CardSelectOffset : _rect.anchoredPosition.y - CardSelectOffset
                );
        });
    }

    public void Draw()
    {
        var _space = m_HandSize - HandCardList.Count;
        var _draw = Mathf.Min(_space, m_DrawSize);

        for (int i = 0; i < _draw; ++i)
        {
            var _index = Random.Range(0, StockCardList.Count - 1);
            HandCardList.Add(StockCardList[_index]);

            CardCreate(_index);

            StockCardList.RemoveAt(_index);
        }

        //ドローが終わったら破棄カードたちを山札に戻す
        foreach (var index in TrashCardList)
            StockCardList.Add(index);
        TrashCardList.Clear();
    }
}