using UnityEngine;

public class Moneda : MonoBehaviour, IInteractivo
{
    [SerializeField] ItemData scriptableDatos;

    public void Interact()
    {
        Debug.Log("Recogiste Item: "+scriptableDatos.nombreItem);
        //Destroy(gameObject);
        scriptableDatos.valor+=10;
        Debug.Log("Este objeto vale:"+ scriptableDatos.valor);
    }
}
