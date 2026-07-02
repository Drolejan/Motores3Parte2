using UnityEngine;

public class Interactor : MonoBehaviour
{
    IInteractivo objectoDet;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<IInteractivo>(out objectoDet))
        {
            Debug.Log("Es Interactivo");
            objectoDet.Interact();
        }
        else
        {
            //Debug.Log("No es interactivo");
        }
    }

    /*
    private void OnCollisionEnter(Collision other)
{
    if(other.TryGetComponent<IInteractivo>(out IInteractivo interactivo))
    {
        objetoDetectado = interactivo;
    }

    private void OnCollisionExit(Collision other)
{
    if(other.TryGetComponent<IInteractivo>(out IInteractivo interactivo))
    {
        if(interactivo == objetoDetectado)
            objetoDetectado = null;
    }
}

public void OnInteract(InputValue value)
{
    if(!value.isPressed)
        return;

    if(!PlayerStateMachine.Instance.CanInteract())
        return;

    objetoDetectado?.Interact();
}
    */

}
