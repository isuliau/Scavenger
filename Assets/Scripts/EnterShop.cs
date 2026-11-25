using JetBrains.Annotations;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public bool close = false;
    public BuildManager buildManager;
    public InventoryOpenAndClose inventoryOpenAndClose;
    public Sprite Epressed;
    public Sprite EE; 
    void Start()
    {
    buildManager = GameObject.Find("BuildManager").GetComponent<BuildManager>();  
    inventoryOpenAndClose = GameObject.Find("CanvasInventory").GetComponent<InventoryOpenAndClose>();  
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
          if (!buildManager.isBuild) gameObject.transform.GetChild(0).gameObject.SetActive(true);
          close = true;
      }
    }
     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            close = false;
        }
    }
    
    public void E()
    {
        if (close && inventoryOpenAndClose.esc.activeSelf) {
        inventoryOpenAndClose.toggleshop(true);
        inventoryOpenAndClose.Inventorytoggle();
        }
    }
}
