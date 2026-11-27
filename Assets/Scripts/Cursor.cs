using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public Transform Pivot;
    public float radius;
    public int form;
    private Transform pivot;
    public float damage;
    public SpriteRenderer spriteRenderer;
    public bool breaksTrees = true;
    public bool breaksRock = false;

    void Start()
    {
        pivot = Pivot.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Time.timeScale == 0) return;
        Vector3 PivotVector = Camera.main.WorldToScreenPoint(Pivot.position);
        PivotVector = (Vector3)Mouse.current.position.ReadValue() - PivotVector;
        float angle = Mathf.Atan2(PivotVector.y, PivotVector.x) * Mathf.Rad2Deg;
        pivot.position = Pivot.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        angle = (angle + 360f) % 360f;
        spriteRenderer.flipX = angle > 90f && angle < 270f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "tree" && ((breaksTrees && collision.GetComponent<tree>().istree) || (breaksRock && !collision.GetComponent<tree>().istree))){ collision.GetComponent<tree>().sliderDamage(damage); collision.transform.GetChild(0).gameObject.SetActive(true); collision.transform.GetChild(1).gameObject.SetActive(true); }
    }
}