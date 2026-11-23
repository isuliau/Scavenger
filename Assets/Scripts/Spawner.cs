using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public Tilemap Tilemap;          
    public GameObject objectToSpawn;        
    public float spawnInterval = 5f;       
    Vector3Int cellPosition;
    BoundsInt bounds;

    public List<Vector3Int> validTilePositions = new List<Vector3Int>();

    private void Start()
    {
        SaveAllTiles();
        InvokeRepeating(nameof(RandomTile), 0, spawnInterval);
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
        GameObject ObjectClone = Instantiate(objectToSpawn, spawnPos, quaternion.identity);
    ObjectClone.SetActive(true);
        }
        else return;
    }
}