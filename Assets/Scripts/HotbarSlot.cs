using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

public class HotbarSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public GameObject cursor;

   public InventoryManager inventoryManager;
    public int quantity;
    public Sprite itemsprite;
    public Sprite background;
    public Sprite mouse;
    public bool isFull;
    [SerializeField] private TMP_Text quantitytext;
    [SerializeField] private Image itemImage;
    public GameObject panel;
    public bool itemsselected;
    public int maxItems;
    private Vector3 scaleSprite; 
   public void AddItem(string itemname, int quantity, Sprite itemsprite)
    {
        itemName = itemname;
        this.quantity += quantity;
        this.itemsprite = itemsprite;
        itemImage.sprite = itemsprite;
        quantitytext.text = this.quantity.ToString();
        quantitytext.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Onleftclick();
        }
    }
    public void SetItem(string newName, int newQuantity, Sprite newSprite)
{
    itemName = newName;
    quantity = newQuantity;
    itemsprite = newSprite;

    bool hasItem = quantity > 0;
    if(hasItem)   itemImage.sprite = itemsprite;
    else  itemImage.sprite = background;
    quantitytext.enabled = hasItem;
    if(hasItem)  quantitytext.text = quantity.ToString();
    else quantitytext.text = "";
    
}
    public void Onleftclick()
    {
        inventoryManager.DeselectSlots();
        panel.SetActive(!panel.activeInHierarchy);
        itemsselected = !panel.activeInHierarchy;
        RefreshCursor();
    }
public void RefreshCursor()
    {
    if (itemsprite != background) cursor.GetComponent<SpriteRenderer>().sprite = itemsprite;
    else cursor.GetComponent<SpriteRenderer>().sprite = mouse;
    if (itemName == "Wood") scaleSprite = new Vector3(0.3f, 0.3f, 1);
    else if (itemName == "Shop") scaleSprite = new Vector3(0.08f, 0.08f, 1);
    else scaleSprite = new Vector3(1, 1, 1);
    cursor.transform.localScale = scaleSprite;
    if (cursor.GetComponent<SpriteRenderer>().sprite != mouse) cursor.GetComponent<Cursor>().breaksTrees = false;
    else cursor.GetComponent<Cursor>().breaksTrees = true;
    }
}
