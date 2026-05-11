using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractivo
{
    [SerializeField] ItemData scriptableDatos;
    
    public void Interact()
    {
        Debug.Log("Recogiste Item: "+scriptableDatos.nombreItem);
        GameManager.Instance.AddItem(scriptableDatos);
        
        AudioSource.PlayClipAtPoint(scriptableDatos.sonidoItem,transform.position);
        Instantiate(scriptableDatos.prefabItem,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
