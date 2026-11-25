using UnityEngine;
using UnityEngine.EventSystems;

public class accept : MonoBehaviour, IPointerClickHandler
{
   public itemSlot buyslot;
   public Money money;
    private int sellvalue;
    private int mult;
    public void OnPointerClick(PointerEventData eventData)
    {
         if(eventData.button != PointerEventData.InputButton.Left) return;
        if(buyslot.itemName == "Wood") mult = 1;
        else if(buyslot.itemName == "Stone") mult = 2;
        else mult = 1;
        sellvalue = mult*buyslot.quantity;
        money.money = money.money + sellvalue;
        money.SetMoney();
        buyslot.itemName = string.Empty;
        buyslot.itemsprite = buyslot.blank;
        buyslot.quantity = 0; 
        buyslot.RefreshUI();
        buyslot.quantitytext.enabled = false; 
    }
}
