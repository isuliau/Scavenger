using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Numerics;

public class BuildManager : MonoBehaviour
{
     public Tilemap tilemap;
    public Spawner treeSpawner;
public Transform cursor;
public InventoryManager inventoryManager;
public InventoryOpenAndClose inventoryOpenAndClose;
public GameObject previewObject;
    public GameObject structureToBuild;
    public string resourceName;
    public int resourceCost;

    public bool isBuild;
    private Vector3Int currentCell;

    void Update()
    {
        if(!isBuild) return;
        UpdatePreview();
        if (Mouse.current.leftButton.wasPressedThisFrame) TryPlaceStructure();
         if (Mouse.current.rightButton.wasPressedThisFrame)
            CancelBuild();
    }
    public void StartBuildMode(GameObject structurePrefab, string name, int ammount)
    {
        if(inventoryManager.TotalItems(name)< ammount) return;
        inventoryOpenAndClose.Inventorytoggle();
        structureToBuild = structurePrefab;
        resourceName = name;
        resourceCost = ammount;
        isBuild = true;
        previewObject = Instantiate(structureToBuild);
        previewObject.GetComponent<Collider2D>().enabled = false;
    }
    void UpdatePreview()
    {
        currentCell = tilemap.WorldToCell(cursor.position);
        UnityEngine.Vector3 position = tilemap.GetCellCenterWorld(currentCell);
        previewObject.transform.position = position;
        bool validPlacement = CanBuildAt(currentCell);
        if(validPlacement) SetpreviewColor(Color.green);
        else SetpreviewColor(Color.red);
    }
    void TryPlaceStructure()
    {
           if (!CanBuildAt(currentCell)) return;
        inventoryManager.subtractItems(resourceName, resourceCost);
        UnityEngine.Vector3 buildPosition = tilemap.GetCellCenterWorld(currentCell);
        Instantiate(structureToBuild, buildPosition, UnityEngine.Quaternion.identity);
        treeSpawner.validTilePositions.Remove(currentCell);
        CancelBuild();

    }
      public void CancelBuild()
    {
        isBuild = false;
        if (previewObject != null)
        Destroy(previewObject);
        previewObject = null;
        structureToBuild = null;
    }
    bool CanBuildAt(Vector3Int cell)
    {
         return treeSpawner.validTilePositions.Contains(cell);
    }
    void SetpreviewColor(Color color)
    {
        SpriteRenderer sprite = previewObject.GetComponent<SpriteRenderer>();
        Color transparentColor = color;
        transparentColor.a = 0.45f;
        sprite.color = transparentColor;
    }
}