using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InventoryOpenAndClose : MonoBehaviour
{
    public GameObject X;
    public GameObject inventory;
    public GameObject craftscreen;
    public GameObject shopscreen;
    public GameObject esc;
    private bool setActive = true;
    public Animator animator;
    public HotbarSlot[] hbs;
    public BuildManager buildManager;
    public bool shop;
    public void Inventorytoggle()
    {
        
        esc.SetActive(!setActive);
        inventory.SetActive(setActive);
        if(!shop) craftscreen.SetActive(setActive);
        else shopscreen.SetActive(setActive);
        setActive = !setActive;
        if(Time.timeScale == 0f) {Time.timeScale = 1f; animator.enabled = true;}
        else {Time.timeScale = 0f; animator.enabled = false;}
        for (int i = 0; i < 4; i++) if(hbs[i].panel.activeInHierarchy) hbs[i].RefreshCursor();
        if(buildManager.isBuild)buildManager.CancelBuild();
    } 
}
