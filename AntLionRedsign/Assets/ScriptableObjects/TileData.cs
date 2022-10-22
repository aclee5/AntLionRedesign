using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    public float timeAdd;
    public bool safe;
    public bool win;
    public bool horizontalEntrance;
    public bool verticalEntrace;
}