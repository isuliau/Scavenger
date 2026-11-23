using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using Vector2 = UnityEngine.Vector2;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float movespeed = 5;
    private Vector2 movement;
    private PlayerControls playerControls;
    private Animator anim;
    public InventoryManager inventoryManager;
    private int slot;
    public BoxCollider2D boxCollider2D;
Rigidbody2D rb;

    void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
playerControls.Enable();        
    }
    private void OnDisable()
    {
playerControls.Disable();        
    }

    void Update()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
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
    void OnTriggerEnter2D()
    {
        
    } 
}
