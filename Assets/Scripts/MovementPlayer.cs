using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float movespeed = 5;
    private Vector2 movement;
    private PlayerControls playerControls;
    private Animator anim;

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
         if(movement.x != 0 && movement.y != 0) {movement = new Vector2 (0,0); anim.SetBool("NotMoving", true);}
        else if(movement == new Vector2 (0,0)) anim.SetBool("NotMoving", true);
        else anim.SetBool("NotMoving", false);
       
    }
    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
