using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public Sprite itemsprite;
    public bool isFull;
    [SerializeField] private TMP_Text quantitytext;
    [SerializeField] private Image itemImage;
    public int maxItems;
    public int AddItem(string itemname, int quantity, Sprite itemsprite)
    {
        if (isFull) return quantity;
        this.itemName = itemname;
        this.itemsprite = itemsprite;
        itemImage.sprite = itemsprite;
        itemImage.enabled = true;
        this.quantity += quantity;
        if (this.quantity >= maxItems)
        {
            int extraItems = this.quantity - maxItems;
            this.quantity = maxItems;
            isFull = true;
            quantitytext.text = this.quantity.ToString();
            quantitytext.enabled = true;
            return extraItems;
        }
        quantitytext.text = this.quantity.ToString();
        quantitytext.enabled = true;
        return 0;
    }

   
}