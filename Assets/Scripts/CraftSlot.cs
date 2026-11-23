
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;
using UnityEngine; //
public class CraftSlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryManager inventoryManager;
    public BuildManager buildManager;
    public int quantityofresource;
    public string typeofresource;
    public GameObject Prefab;
   
    public void OnPointerClick(PointerEventData eventData)
    {
           if(inventoryManager.TotalItems(typeofresource)>= quantityofresource)
        {
            for(int i = 0; i<inventoryManager.itemSlot.Length; i++) inventoryManager.itemSlot[i].RefreshUI();
            buildManager.StartBuildMode(Prefab, typeofresource, quantityofresource);
    }
}
}
