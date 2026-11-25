using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Money : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI moneycounter;
    
    public void SetMoney()
    {
        if(money>9)moneycounter.text = money.ToString();
        else moneycounter.text = "0" + money.ToString() ;
    }
}
