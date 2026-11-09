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

  public void AddItem(string itemname, int quantity, Sprite itemsprite)
    {
        this.itemName = itemname;
        this.quantity = quantity;
        this.itemsprite = itemsprite;
        isFull = true;

        quantitytext.text = quantity.ToString();
        quantitytext.enabled = true;
        itemImage.sprite = itemsprite;
    }
}
