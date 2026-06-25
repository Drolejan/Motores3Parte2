using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryInput : MonoBehaviour
{
    [SerializeField] private GameObject panelInventario;

    public void OnInventory(InputValue value)
    {
        if (!value.isPressed) return;

        bool isOpen = !panelInventario.activeSelf;
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