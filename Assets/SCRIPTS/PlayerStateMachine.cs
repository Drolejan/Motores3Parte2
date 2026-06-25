using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerStateMachine Instance;

    [SerializeField] private PlayerState currentState = PlayerState.Gameplay;

    public PlayerState CurrentState => currentState;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeState(PlayerState newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        Debug.Log("Nuevo estado del jugador: " + currentState);
    }

    public bool CanMove()
    {
        return currentState == PlayerState.Gameplay;
    }

    public bool CanInteract()
    {
        return currentState == PlayerState.Gameplay;
    }
}