using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    public Tilemap map;
    
    [SerializeField]
    private List<TileData> tileDatas;


    public Dictionary<TileBase, TileData> dataFromTiles;

    public void Awake()
    {
        Debug.Log("awake");
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }



}