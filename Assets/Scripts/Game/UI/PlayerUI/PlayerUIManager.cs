﻿using System;
using UnityEngine;
using Player;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private PlayerUI m_prefab;

#if UNITY_EDITOR
    [Header("Debug"), SerializeField]
#endif
    private PlayerUI[] m_playerUIs;

    public static event Action
        Event_ButtonPlace,
        Event_ButtonTurnEnd;

    public void Initialize()
    {
        var _players = PlayerManager.Singleton.Players;
        m_playerUIs = new PlayerUI[_players.Count];
        for (int i = 0, len = m_playerUIs.Length; i < len; ++i)
        {
            m_playerUIs[i] = Instantiate(m_prefab, transform);
            m_playerUIs[i].Initialize(_players[i], null);
            m_playerUIs[i].Event_ButtonPlace += () => Event_ButtonPlace?.Invoke();
            m_playerUIs[i].Event_ButtonTurnEnd += () => Event_ButtonTurnEnd?.Invoke();
            m_playerUIs[i].Disable();
        }
    }

    public void Enable(int index_) => m_playerUIs[index_].Enable();

    public void TurnInitialize()
    {
        foreach (var ui in m_playerUIs)
        {
            ui.TurnInitialize();
        }
    }
}