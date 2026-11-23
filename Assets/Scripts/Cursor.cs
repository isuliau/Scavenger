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
    
    public bool breaksTrees = true;

    void Start()
    {
        pivot = Pivot.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }

    void Update()
    {
        if(Time.timeScale == 0) return;
        Vector3 PivotVector = Camera.main.WorldToScreenPoint(Pivot.position);
        PivotVector = (Vector3)Mouse.current.position.ReadValue() - PivotVector;

        float angle = Mathf.Atan2(PivotVector.y, PivotVector.x) * Mathf.Rad2Deg;

        pivot.position = Pivot.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "tree" && breaksTrees){ collision.GetComponent<tree>().sliderDamage(damage); collision.transform.GetChild(0).gameObject.SetActive(true); collision.transform.GetChild(1).gameObject.SetActive(true); }
    }
}