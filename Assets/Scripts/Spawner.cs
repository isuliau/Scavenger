using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public Tilemap Tilemap;          
    public GameObject objectToSpawn1;
    public GameObject objectToSpawn2;        
    public float spawnInterval = 5f;       
    Vector3Int cellPosition;
    BoundsInt bounds;
    
    private int chooseThingToSpawn;

    public List<Vector3Int> validTilePositions = new List<Vector3Int>();

    private void Start()
    {
        SaveAllTiles();
        InvokeRepeating(nameof(RandomTile), 0, spawnInterval);
        for (int i = 0; i < 5; i++)
        {
            RandomTile();
        }
    }
    
    private void SaveAllTiles()
    {
        validTilePositions.Clear();
        bounds = Tilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (Tilemap.HasTile(pos)) 
            {
                validTilePositions.Add(pos);
            }
        }
    }
    private void RandomTile()
    { if(validTilePositions.Count > 0){
        int randomindex = UnityEngine.Random.Range(0, validTilePositions.Count);
        cellPosition = validTilePositions[randomindex];
        validTilePositions.Remove(cellPosition);
        UnityEngine.Vector3 spawnPos = Tilemap.GetCellCenterWorld(cellPosition) + UnityEngine.Vector3.up * 0.25f;
        chooseThingToSpawn = UnityEngine.Random.Range(0, 2);
        GameObject ObjectClone;
        if (chooseThingToSpawn == 0) ObjectClone = Instantiate(objectToSpawn1, spawnPos, quaternion.identity);
        else ObjectClone = Instantiate(objectToSpawn2, spawnPos, quaternion.identity);
        ObjectClone.SetActive(true);
        }
        else return;
    }
}