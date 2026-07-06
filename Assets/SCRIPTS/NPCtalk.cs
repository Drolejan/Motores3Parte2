using UnityEngine;

public class NPCtalk : MonoBehaviour, IInteractivo
{
    [SerializeField] GameObject panelDialogo;
    public void Interact()
    {
        panelDialogo.SetActive(true);
        PlayerStateMachine.Instance.ChangeState(PlayerState.Talking);
        Invoke("cerrarPanel",3f);
    }
    public void cerrarPanel()
    {
        panelDialogo.SetActive(false);
        PlayerStateMachine.Instance.ChangeState(PlayerState.Gameplay);
    }
}
