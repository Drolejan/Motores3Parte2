using UnityEngine;

public class Moneda : MonoBehaviour, IInteractivo
{
    [SerializeField] ItemData scriptableDatos;
    AudioSource au;

    void Start()
    {
        au=GameObject.FindFirstObjectByType<AudioSource>();
    }
    public void Interact()
    {
        Debug.Log("Recogiste Item: "+scriptableDatos.nombreItem);
        au.PlayOneShot(scriptableDatos.sonidoItem);
        Instantiate(scriptableDatos.prefabItem,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
