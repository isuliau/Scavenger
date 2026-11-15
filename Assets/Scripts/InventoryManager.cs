using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public itemSlot[] itemSlot;
    public HotbarSlot[] hotbarSlot;
   public int AddItem(string itemname, int quantity, Sprite itemsprite)
    {
       for (int i = 0; i < itemSlot.Length; i++)
       {
        if ((!itemSlot[i].isFull && itemSlot[i].itemName == itemname) || itemSlot[i].quantity == 0)
            {
                int leftoveritems = itemSlot[i].AddItem(itemname, quantity, itemsprite);
                if (leftoveritems > 0) leftoveritems = AddItem(itemname, leftoveritems, itemsprite);
                if(i<4) hotbarSlot[i].AddItem(itemname, quantity, itemsprite);
                return leftoveritems;
            }
        
       }
    return quantity;
    } 
     public int TotalItems(string Itemname)
  {
    int total = 0; 

    for(int i = 0; i<itemSlot.Length; i++)
        {
            if(itemSlot[i].itemName == Itemname) total += itemSlot[i].quantity;
        }
    return total;
  }


public void PlayerHotbar(int slot)
    {
        hotbarSlot[slot].Onleftclick();
    }
public void DeselectSlots()
    {
        for (int i = 0; i < hotbarSlot.Length; i++)
        {
            hotbarSlot[i].panel.SetActive(false);
        }
    }
}