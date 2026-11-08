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

    private List<Vector3Int> validTilePositions = new List<Vector3Int>();

    private void Start()
    {
        SaveAllTiles();
        InvokeRepeating(nameof(RandomTile), spawnInterval, spawnInterval);
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
        UnityEngine.Vector3 spawnPos = new UnityEngine.Vector3(Tilemap.GetCellCenterWorld(cellPosition).x, Tilemap.GetCellCenterWorld(cellPosition).y+0.25f, 0);
        GameObject ObjectClone = Instantiate(objectToSpawn, spawnPos, quaternion.identity);
    ObjectClone.SetActive(true);
        }
        else return;
    }
}