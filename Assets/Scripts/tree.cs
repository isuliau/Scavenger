using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class tree : MonoBehaviour
{
    public GameObject item;
    private Slider slider;
     private bool hasDroppedWood;
     public Spawner spawner;
    void Start()
    {
        
        slider = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Slider>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
         if (hasDroppedWood) return;
         if (!collision.CompareTag("Weapon")) return;
        slider.gameObject.SetActive(true);
        if(slider.value > 0f) return;
        Destroy(gameObject);
        hasDroppedWood = true;
        spawner.validTilePositions.Add(spawner.Tilemap.WorldToCell(transform.position - Vector3.up * 0.25f));
        GameObject ObjectClone = Instantiate(item, transform.position - new Vector3(0f, 1f, 0f), quaternion.identity);
        ObjectClone.SetActive(true);
    
    }
}