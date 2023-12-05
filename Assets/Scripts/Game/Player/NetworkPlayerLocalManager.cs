﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerLocalManager : MonoBehaviour
{
    public MapChip m_SelectChip { get; private set; }
    Vector2 m_Position;

    void OnEnable()
    {
        PlayerInputManager.OnMouseMainClickEvent += OnMouse_MainClick;
        PlayerInputManager.OnDragStartEvent += OnMouse_DragStart;
        PlayerInputManager.OnDragCancelEvent += OnMouse_DragCancel;
    }
    void OnDisable()
    {
        PlayerInputManager.OnMouseMainClickEvent -= OnMouse_MainClick;
        PlayerInputManager.OnDragStartEvent -= OnMouse_DragStart;
        PlayerInputManager.OnDragCancelEvent -= OnMouse_DragCancel;
    }

    void OnMouse_MainClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(PlayerInputManager.m_Pos);

        int mask = 1 << Name.Layer.Map | 1 << Name.Layer.UI;
        if(Physics.Raycast(ray, out var hit, Mathf.Infinity, mask))
        {
            var map = hit.collider.GetComponent<MapChip>();
            if(m_SelectChip != map)
            {
                m_SelectChip = map;
            }
        }
    }

    void OnMouse_DragStart()
    {
        m_Position = PlayerInputManager.m_Pos;
        PlayerInputManager.OnMouseMovePerformEvent += OnMouse_MovePerform;
    }

    void OnMouse_DragCancel()
    {
        PlayerInputManager.OnMouseMovePerformEvent -= OnMouse_MovePerform;
        CameraManager.Singleton.SetFreeLookCamIsMove(false);
    }

    void OnMouse_MovePerform()
    {
        if ((m_Position - PlayerInputManager.m_Pos).magnitude >= 20.0f)
        {
            CameraManager.Singleton.SetFreeLookCamIsMove(true);
            PlayerInputManager.OnMouseMovePerformEvent -= OnMouse_MovePerform;
        }
    }
}