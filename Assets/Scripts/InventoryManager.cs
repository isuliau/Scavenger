using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public itemSlot[] itemSlot;
   public void AddItem(string itemname, int quantity, Sprite itemsprite)
    {
       for (int i = 0; i < itemSlot.Length; i++)
       {
        if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemname, quantity, itemsprite);
                return;
            }
       }
    }

}