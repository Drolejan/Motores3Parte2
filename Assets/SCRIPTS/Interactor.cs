using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    IInteractivo objetoDet;
    [SerializeField] GameObject panelTxt;
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
        panelTxt.SetActive(true);
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.TryGetComponent<IInteractivo>(out IInteractivo interactivo))
        {
        objetoDet = null;
        panelTxt.SetActive(false);
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






