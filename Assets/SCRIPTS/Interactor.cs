using UnityEngine;

public class Interactor : MonoBehaviour
{
    IInteractivo objectoDet;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IInteractivo>(out objectoDet))
        {
            Debug.Log("Es Interactivo");
            objectoDet.Interact();
        }
        else
        {
            Debug.Log("No es interactivo");
        }
    }

}
