﻿using UnityEngine;

[CreateAssetMenu(menuName = "MO_SO/Destry_Wall")]
public class MO_Destry_SO_Wall : MapObject_SO_Template
{
    public override MapObject ObjectSpawn(Vector2Int posdata_, Vector3 pos_, Transform tf_)
    {
        return base.ObjectSpawn(posdata_, pos_, tf_);
    }
}