using UnityEngine;

public class Interactor : MonoBehaviour
{
    IInteractivo objectoDet;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IInteractivo>() != null)
        {
            Debug.Log("Es Interactivo");
            objectoDet=collision.gameObject.GetComponent<IInteractivo>();
            objectoDet.Interact();
        }
        else
        {
            Debug.Log("No es interactivo");
        }
    }

}
