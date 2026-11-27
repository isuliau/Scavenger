
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;
using UnityEngine;
using JetBrains.Annotations; //
public class CraftSlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryManager inventoryManager;
    public BuildManager buildManager;
    public int[] quantityofresource;
    public string[] typeofresource;
    public GameObject Prefab;
   public bool structure;
    public string itemname;
    public int quantity; 
    public Sprite itemsprite;
     public void OnPointerClick(PointerEventData eventData)
    {
        if (!inventoryManager.HasResources(typeofresource, quantityofresource)) return;

        if (structure)
        {
            buildManager.StartBuildMode(Prefab, typeofresource, quantityofresource);
        }
        else
        {
            inventoryManager.SubtractResources(typeofresource, quantityofresource);
            inventoryManager.AddItem(itemname, quantity, itemsprite);
        }

        for (int i = 0; i < inventoryManager.itemSlot.Length; i++)
            inventoryManager.itemSlot[i].RefreshUI();
    }
}