using UnityEngine;
using TMPro;
using System;

public class venderItem : MonoBehaviour
{
    String name0;
    public void vender()
    {
        name0=GetComponent<TextMeshProUGUI>().text;
        foreach(ItemData i in GameManager.Instance.Inventario)
        {
            if (i.name == name0)
            {
                GameManager.Instance.Inventario.Remove(i);
                Destroy(gameObject);
                return;
            }
        }
        
    }
}
