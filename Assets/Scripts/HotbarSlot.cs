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
    
    public void Onleftclick()
    {
        inventoryManager.DeselectSlots();
        panel.SetActive(!panel.activeInHierarchy);
        itemsselected = !panel.activeInHierarchy;
    if (itemsprite != background) cursor.GetComponent<SpriteRenderer>().sprite = itemsprite;
    else cursor.GetComponent<SpriteRenderer>().sprite = mouse;
    if (itemName == "Wood") scaleSprite = new Vector3(0.3f, 0.3f, 1);
    else scaleSprite = new Vector3(1, 1, 1);
    cursor.transform.localScale = scaleSprite;
    if (cursor.GetComponent<SpriteRenderer>().sprite != mouse) cursor.GetComponent<Cursor>().breaksTrees = false;
    else cursor.GetComponent<Cursor>().breaksTrees = true;
    }

}
