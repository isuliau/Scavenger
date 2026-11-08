using Unity.VisualScripting;
using UnityEngine;

public class InventoryOpenAndClose : MonoBehaviour
{
    public GameObject X;
    public GameObject inventory;
    public GameObject esc;
    private bool setActive = true;
    public Animator animator;

    public void Inventorytoggle()
    {
        esc.SetActive(!setActive);
        inventory.SetActive(setActive);
        X.SetActive(setActive);
        setActive = !setActive;
        if(Time.timeScale == 0f) {Time.timeScale = 1f; animator.enabled = true;}
        else {Time.timeScale = 0f; animator.enabled = false;}
    } 
}
