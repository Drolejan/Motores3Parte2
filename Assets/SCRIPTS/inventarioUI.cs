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
        GameManager.Instance.OnItemAdded+=itemsUpdate;
        SceneManager.activeSceneChanged+=cambioEscena;
        refreshInventory();
    }
    void itemsUpdate(ItemData nuevoItem)
    {
        GameObject esteItem=Instantiate(datosItemPrefab,listaInventario);
        esteItem.GetComponent<TextMeshProUGUI>().text=nuevoItem.name;
    }
    void refreshInventory()
    {
        listaInventario=GameObject.FindAnyObjectByType<GridLayoutGroup>().GetComponent<Transform>();
        listaInventario.transform.parent.gameObject.SetActive(false);

        foreach(ItemData i in GameManager.Instance.Inventario)
        {
            GameObject esteItem=Instantiate(datosItemPrefab,listaInventario);
            esteItem.GetComponent<TextMeshProUGUI>().text=i.name;
        }
    }
    void cambioEscena(Scene actual,Scene siguente)
    {
        Debug.Log("Cambiamos de escena "+actual.name+" a escena "+siguente.name);
        refreshInventory();
    }

    
}

/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class inventarioUI : MonoBehaviour
{
    public GameObject datosItemPrefab;
    public Transform listaInventario;

    private void Start()
    {
        GameManager.Instance.OnInventoryChanged += RefreshInventory;
        SceneManager.activeSceneChanged += CambioEscena;

        RefreshInventory();
    }

    private void RefreshInventory()
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

    private void CambioEscena(Scene actual, Scene siguiente)
    {
        RefreshInventory();
    }
}
*/
