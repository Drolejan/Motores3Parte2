using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    IInteractivo objetoDet;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<IInteractivo>(out objetoDet))
        {
            Debug.Log("Es Interactivo");
            objetoDet.Interact();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<IInteractivo>(out IInteractivo interactivo))
        {
        objetoDet = interactivo;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.TryGetComponent<IInteractivo>(out IInteractivo interactivo))
        {
        objetoDet = null;
        }
    }
    public void OnInteract(InputValue value)
    {
    if(!value.isPressed)
        return;
    if(!PlayerStateMachine.Instance.CanInteract())
        return;
    objetoDet?.Interact();
    }
}






