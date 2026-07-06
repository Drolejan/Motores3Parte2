using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryInput : MonoBehaviour
{
    [SerializeField] private GameObject panelInventario;
    bool isOpen;

    public void OnInventory(InputValue value)
    {
        if (!value.isPressed) return;
        if(!PlayerStateMachine.Instance.CanInteract()&&!isOpen) return;

        isOpen = !panelInventario.activeSelf;
        panelInventario.SetActive(isOpen);

        if (isOpen)
        {
            PlayerStateMachine.Instance.ChangeState(PlayerState.InventoryOpen);
        }
        else
        {
            PlayerStateMachine.Instance.ChangeState(PlayerState.Gameplay);
        }
    }
}