using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
using UnityEngine.Audio;

public class tree : MonoBehaviour
{
    public GameObject item;
    public GameObject slider;
     private bool hasDroppedWood;
     public Spawner spawner;
    void OnTriggerEnter2D(Collider2D collision)
    {
         if (hasDroppedWood) return;
         if (!collision.CompareTag("Weapon") || !collision.GetComponent<Cursor>().breaksTrees) return;
        slider.gameObject.SetActive(true);
        if(slider.transform.localScale.x > 0.2f) return;
        hasDroppedWood = true;
        spawner.validTilePositions.Add(spawner.Tilemap.WorldToCell(transform.position - Vector3.up * 0.25f));
        GameObject ObjectClone = Instantiate(item, transform.position, quaternion.identity);
        ObjectClone.SetActive(true);
        Destroy(gameObject);
    }
    public void sliderDamage(float damage)
    {
        float realdamage = damage/100;
        Vector3 scale = slider.transform.localScale;
        scale.x = Mathf.Max(0f, scale.x - realdamage);
        slider.transform.localScale = scale;
    }
}