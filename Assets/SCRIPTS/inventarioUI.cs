using UnityEngine;
using TMPro;

public class inventarioUI : MonoBehaviour
{
    public GameObject datosItemPrefab;
    public Transform listaInventario;
    void Start()
    {
        GameManager.Instance.OnItemAdded+=itemsUpdate;
        
    }

    void itemsUpdate(ItemData nuevoItem)
    {
        GameObject esteItem=Instantiate(datosItemPrefab,listaInventario);
        esteItem.GetComponent<TextMeshProUGUI>().text=nuevoItem.name;
    }
}
