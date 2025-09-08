using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{

    public PlayerMovementSystem MovementSystem;

    private void OnMove(InputValue value)
        => MovementSystem.InputMovement(value.Get<Vector2>());

    private void OnJump(InputValue value)
        => MovementSystem.InputJump();

    private void OnSprint(InputValue value)
        => MovementSystem.InputSprint(value.isPressed);

}
