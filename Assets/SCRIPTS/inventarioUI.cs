using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inventarioUI : MonoBehaviour
{
    public GameObject datosItemPrefab;
    public Transform listaInventario;
    void Start()
    {
        GameManager.Instance.OnInventoryChanged+=refreshInventory;
        SceneManager.activeSceneChanged+=cambioEscena;
        refreshInventory();
    }
    
    void refreshInventory()
    {
         foreach (Transform child in listaInventario)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemData item in GameManager.Instance.Inventario)
        {
            GameObject nuevoSlot = Instantiate(datosItemPrefab, listaInventario);
            nuevoSlot.GetComponent<SlotInventarioUI>().Configurar(item);
        }
    }
    void cambioEscena(Scene actual,Scene siguente)
    {
        Debug.Log("Cambiamos de escena "+actual.name+" a escena "+siguente.name);
        //refreshInventory();
    }

    
}

