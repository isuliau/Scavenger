using System.Collections;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField] private string itemname;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    private InventoryManager inventoryManager;
    private bool isCollected;

    void Start()
    {
        inventoryManager = GameObject.Find("CanvasInventory").GetComponent<InventoryManager>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isCollected) return;

        if (collision.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.transform.position, .03f);
            if (transform.position.x > collision.transform.position.x - 0.5f && transform.position.x < collision.transform.position.x + 0.5f && transform.position.y > collision.transform.position.y - 0.5f && transform.position.y < collision.transform.position.y + 0.5f)
            {
                
                isCollected = true;
                GetComponent<Collider2D>().enabled = false;
                inventoryManager.AddItem(itemname, quantity, sprite);
                Destroy(gameObject);
            }
        }
    }
}