using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractivo
{
    [SerializeField] ItemData scriptableDatos;
    
    public void Interact()
    {
        Debug.Log("Recogiste Item: "+scriptableDatos.nombreItem);

        switch (scriptableDatos.tipo)
        {
            case ItemType.Moneda:
            //Aqui sumamos dinero a nuestra cartera
            Debug.Log("Ahora tienes mas dinero");
            
            break;
            case ItemType.Collecionable:
            //Aqui agregamos un item a nuestro inventario
            Debug.Log("Puedes venderlo en la tienda");

            break;
        }

        AudioSource.PlayClipAtPoint(scriptableDatos.sonidoItem,transform.position);
        Instantiate(scriptableDatos.prefabItem,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
