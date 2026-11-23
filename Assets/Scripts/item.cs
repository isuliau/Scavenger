using System.Collections;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField] private string itemname;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    private InventoryManager inventoryManager;
    public bool touched = false;
    public Collider2D player;
    
        void Start()
    {
        inventoryManager = GameObject.Find("CanvasInventory").GetComponent<InventoryManager>();
    }
    void Update()
    {
        if (!touched) return;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .09f);
            if (transform.position.x > player.transform.position.x - 0.5f && transform.position.x < player.transform.position.x + 0.5f && transform.position.y > player.transform.position.y - 0.5f && transform.position.y < player.transform.position.y + 0.5f)
            {
                int leftoveritems = inventoryManager.AddItem(itemname, quantity, sprite);
                if(leftoveritems <= 0)
                Destroy(gameObject);
                else 
                quantity = leftoveritems;
            }
    }
}