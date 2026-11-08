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
    public Slider slider;
    

    void Start()
    {
        pivot = Pivot.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }

    void Update()
    {
        
        Vector3 PivotVector = Camera.main.WorldToScreenPoint(Pivot.position);
        PivotVector = (Vector3)Mouse.current.position.ReadValue() - PivotVector;

        float angle = Mathf.Atan2(PivotVector.y, PivotVector.x) * Mathf.Rad2Deg;

        pivot.position = Pivot.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "tree"){ slider = collision.transform.GetChild(0).transform.GetChild(0).GetComponent<Slider>(); slider.value = slider.value - damage; Debug.Log("Worked");}
    }
}