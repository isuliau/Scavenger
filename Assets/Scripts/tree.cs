using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class tree : MonoBehaviour
{
    public GameObject item;
    private Slider slider;
    void Start()
    {
        slider = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Slider>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        slider.gameObject.SetActive(true);
        if(slider.value <= 0f) {Destroy(gameObject);
         GameObject ObjectClone = Instantiate(item, transform.position - new Vector3(0f, 1f, 0f), quaternion.identity);
         ObjectClone.SetActive(true);
    }
    }
}