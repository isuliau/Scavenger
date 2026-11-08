using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField] private string itemname;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    private InventoryManager inventoryManager;
    void Start()
    {
        inventoryManager = GameObject.Find("CanvasInventory").GetComponent<InventoryManager>();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.transform.position, .03f);
        if (transform.position == collision.transform.position) Destroy(gameObject);
        }
    
    }
}
