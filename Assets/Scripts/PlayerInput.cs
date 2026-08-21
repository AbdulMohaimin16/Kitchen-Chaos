using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();
    }

    public Vector2 PlayerInputNormalized()
    {
        Vector2 inputMovementVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        inputMovementVector = inputMovementVector.normalized;

        return inputMovementVector;
    }
}
