using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public bool close = false;
    public BuildManager buildManager;
    public Sprite Epressed;
    public Sprite EE;
    void Start()
    {
    buildManager = GameObject.Find("BuildManager").GetComponent<BuildManager>();        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
      if(!buildManager.isBuild)  gameObject.transform.GetChild(0).gameObject.SetActive(true);
      close = true;
    }
     void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        close = false;
    }
    
    public void E()
    {
       // if (!close) {gameObject.GetComponent<SpriteRenderer>().sprite = EE;return;}
    //    gameObject.GetComponent<SpriteRenderer>().sprite = Epressed;
    }
}
