using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using Vector2 = UnityEngine.Vector2;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float movespeed = 5;
    private Vector2 movement;
    private InputAction moveAction;
    private Animator anim;
    public InventoryManager inventoryManager;
    private int slot;
Rigidbody2D rb;
private EnterShop shop;

    void Awake()
    {
        moveAction = GetComponent<PlayerInput>().actions.FindAction("Movement/Move", true);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        movement = movement = moveAction.ReadValue<Vector2>();
        anim.SetFloat("X", movement.x); anim.SetFloat("Y", movement.y);
        if(movement == new Vector2 (0,0)) anim.SetBool("NotMoving", true);
        else anim.SetBool("NotMoving", false);
       
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }

    public void OnHotbarKeyPressed(InputAction.CallbackContext context)
    {
     slot = Mathf.RoundToInt(context.ReadValue<float>())-1;
        
     if (slot != -1) inventoryManager.PlayerHotbar(slot);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shop"))
        {
            shop = collision.GetComponent<EnterShop>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnterShop>() == shop) shop = null;
    }

    public void  E()
    {
        if(shop != null) shop.E();
    }
}
