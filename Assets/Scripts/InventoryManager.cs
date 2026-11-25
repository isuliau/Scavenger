using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Sprite blank;
    public itemSlot[] itemSlot;
    public HotbarSlot[] hotbarSlot;
    public string Name;
    public int Quantity;
    public Sprite itemSprite;
    public bool isfull;
   public int AddItem(string itemname, int quantity, Sprite itemsprite)
    {
       for (int i = 0; i < itemSlot.Length; i++)
       {
        if (!itemSlot[i].isFull && itemSlot[i].itemName == itemname)
            {
                int leftoveritems = itemSlot[i].AddItem(itemname, quantity, itemsprite);
                if (leftoveritems > 0) leftoveritems = AddItem(itemname, leftoveritems, itemsprite);
                if(i<4) {hotbarSlot[i].AddItem(itemname, quantity, itemsprite); for (int x = 0; x < 4; x++) if(hotbarSlot[x].panel.activeInHierarchy) hotbarSlot[x].RefreshCursor();}
                return leftoveritems;
            }
       }

       for (int i = 0; i < itemSlot.Length; i++)
       {
        if (itemSlot[i].quantity == 0)
            {
                int leftoveritems = itemSlot[i].AddItem(itemname, quantity, itemsprite);
                if (leftoveritems > 0) leftoveritems = AddItem(itemname, leftoveritems, itemsprite);
                if(i<4) {hotbarSlot[i].AddItem(itemname, quantity, itemsprite); for (int x = 0; x < 4; x++) if(hotbarSlot[x].panel.activeInHierarchy) hotbarSlot[x].RefreshCursor();}
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
  public int subtractItems(string Itemname, int ammount)
  {
    if (ammount <= 0) return 0;

    int remaining = ammount;
    for(int i = 0; i<itemSlot.Length; i++)
        {
            if(itemSlot[i].itemName == Itemname && itemSlot[i].quantity > 0)
            {
                int removed = Mathf.Min(itemSlot[i].quantity, remaining);
                itemSlot[i].quantity -= removed;
                remaining -= removed;

                if (itemSlot[i].quantity == 0)
                {
                    itemSlot[i].itemName = string.Empty;
                    itemSlot[i].itemsprite = itemSlot[i].blank;
                }

                itemSlot[i].RefreshUI();
            }
            if(remaining == 0) break;
        }

    RefreshHotbar();
    return ammount - remaining;
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
            hotbarSlot[i].itemsselected = false;
        }
    }
    private itemSlot selectedSlot;
public void SelectOrSwap(itemSlot clickedSlot)
{
    if (selectedSlot == null)
    {selectedSlot = clickedSlot;selectedSlot.panel.SetActive(true);return;}
    if (selectedSlot == clickedSlot)
    {selectedSlot.panel.SetActive(false);selectedSlot = null;return;}
    selectedSlot.SwapContents(clickedSlot);
    selectedSlot.panel.SetActive(false);
    selectedSlot = null;
    RefreshHotbar();
}

private void RefreshHotbar()
{
    for (int i = 0; i < hotbarSlot.Length && i < itemSlot.Length; i++)
    {
        hotbarSlot[i].SetItem(itemSlot[i].itemName, itemSlot[i].quantity, itemSlot[i].itemsprite
        );
    }
}
}
