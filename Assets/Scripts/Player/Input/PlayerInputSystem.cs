using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{

    public PlayerSwordHandler SwordHandler;
    public PlayerMovementSystem MovementSystem;
    public PlayerInput PlayerInput;

    private void OnEnable()
    {
        PlayerInput.actions["Sprint"].performed += OnSprintPerformed;
        PlayerInput.actions["Sprint"].canceled += OnSprintCanceled;
    }

    private void OnDisable()
    {
        PlayerInput.actions["Sprint"].performed -= OnSprintPerformed;
        PlayerInput.actions["Sprint"].canceled -= OnSprintCanceled;
    }

    private void OnAttack(InputValue value)
        => SwordHandler.Attack();

    private void OnMove(InputValue value)
        => MovementSystem.InputMovement(value.Get<Vector2>());

    private void OnJump(InputValue value)
        => MovementSystem.InputJump();

    private void OnToggleWeapon(InputValue value)
        => SwordHandler.ToggleSwordHandling();

    private void OnSprintPerformed(InputAction.CallbackContext context)
        => MovementSystem.InputSprint(true);

    private void OnSprintCanceled(InputAction.CallbackContext context)
        => MovementSystem.InputSprint(false);

}
