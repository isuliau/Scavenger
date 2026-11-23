using JetBrains.Annotations;
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
    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
          if (!buildManager.isBuild) gameObject.transform.GetChild(0).gameObject.SetActive(true);
          close = true;
          gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = EE;
      }
    }
     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            close = false;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = EE;
        }
    }
    
    public void E()
    {
        if (close) {gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Epressed;}
    }
}
