using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int quantity;
    public Sprite itemsprite;
    public Sprite blank;
    public GameObject panel;
    public bool isFull;
    [SerializeField] public TMP_Text quantitytext;
    [SerializeField] private Image itemImage;
    public InventoryManager inventoryManager;
    public int maxItems;
    public int AddItem(string itemname, int quantity, Sprite itemsprite)
    {
        if (isFull) return quantity;
        itemName = itemname;
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
public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Onleftclick();
        }
    }
    
    public void Onleftclick()
    {
        inventoryManager.SelectOrSwap(this);
    }
    public void SwapContents(itemSlot other)
{
    (itemName, other.itemName) = (other.itemName, itemName);
    (quantity, other.quantity) = (other.quantity, quantity);
    (itemsprite, other.itemsprite) = (other.itemsprite, itemsprite);
// I didnt know this before
    RefreshUI();
    other.RefreshUI();
}

public void RefreshUI()
{
    isFull = quantity >= maxItems;
    bool hasItem = quantity > 0;
    itemImage.enabled = hasItem;
    if (hasItem)  itemImage.sprite = itemsprite;
    else itemImage.sprite = blank;
    quantitytext.enabled = hasItem;
    quantitytext.text = hasItem ? quantity.ToString() : "";
}
   
}
