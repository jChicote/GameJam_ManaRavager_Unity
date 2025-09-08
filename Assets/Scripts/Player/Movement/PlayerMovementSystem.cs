using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{

    [Header("Required Dependencies")]
    public Animator PlayerAnimator;
    public CharacterController CharacterController;

    [Header("Reference Points")]
    public Transform FeetPoint;

    [Header("Movement Fields")]
    public float MovementSpeed = 1f;
    public float SprintSpeed = 1f;

    [Header("Vertical Fields")]
    public float FallTimeout = 1f;
    public float Gravity = -9.81f;
    public float GroundedDetectionRadius = 1f;
    public LayerMask GroundLayers;
    public float JumpHeight = 1f;
    public float JumpTimeout = .5f;
    public float TerminalVelocity = 53f;

    private Vector3 _inputDirection = Vector3.zero;
    private bool _canJump;
    private bool _isGrounded;
    private bool _isSprinting;
    private float _fallTimeoutDelta;
    private Vector3 _finalMovement = Vector3.zero;
    private float _jumpTimeoutDelta;
    private float _verticalVelocity;
    private float _animationMotionSpeedBlendTime;

    private void Start()
    {
        _fallTimeoutDelta = FallTimeout;
    }

    private void FixedUpdate()
    {
        CalculateGravity();
        GroundedChecks();
        GroundPlayer();
        CalculateJump();
        Move();
    }

    public void InputMovement(Vector2 inputDirection)
        => _inputDirection = new Vector3(inputDirection.x, 0, inputDirection.y);

    public void InputJump()
        => _canJump = true;

    public void InputSprint(bool isSprinting)
        => _isSprinting = isSprinting;

    public void CalculateJump()
    {
        var canRunJump = _canJump && _isGrounded;
        if (canRunJump && _jumpTimeoutDelta <= 0f)
        {
            PlayerAnimator.SetBool(PlayerAnimationParams.PlayerJump, true);
            _verticalVelocity = Mathf.Sqrt(JumpHeight * -2 * Gravity);
            _fallTimeoutDelta -= Time.fixedDeltaTime;
        }

        if (canRunJump && _jumpTimeoutDelta > 0f)
            _jumpTimeoutDelta -= Time.fixedDeltaTime;
    }

    private void CalculateGravity()
    {
        if (_isGrounded || _verticalVelocity >= TerminalVelocity) return;

        _verticalVelocity += Gravity * Time.fixedDeltaTime;
    }

    private void GroundedChecks()
    {
        _isGrounded = Physics.CheckSphere(FeetPoint.position, GroundedDetectionRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        PlayerAnimator.SetBool(PlayerAnimationParams.IsGrounded, _isGrounded);
    }

    private void GroundPlayer()
    {
        if (_isGrounded)
        {
            _fallTimeoutDelta = FallTimeout;
            PlayerAnimator.SetBool(PlayerAnimationParams.PlayerJump, false);
            PlayerAnimator.SetBool(PlayerAnimationParams.PlayerFreeFall, false);

            if (_verticalVelocity < 0f)
                _verticalVelocity = -2f;

            return;
        }
        else
        {
            if (_fallTimeoutDelta <= 0f)
                PlayerAnimator.SetBool(PlayerAnimationParams.PlayerFreeFall, true);
            else
                _fallTimeoutDelta -= Time.fixedDeltaTime;

            _jumpTimeoutDelta = JumpTimeout;
            _canJump = false;
        }
    }

    public void Move()
    {
        var targetSpeed = _isSprinting ? SprintSpeed : MovementSpeed;

        _finalMovement = _inputDirection * targetSpeed * Time.fixedDeltaTime;
        _finalMovement.y = _verticalVelocity * Time.fixedDeltaTime;
        CharacterController.Move(_finalMovement);

        var inputMagnitude = _inputDirection.magnitude;
        var blendTarget = 0f;
        if (inputMagnitude > 0.01f)
            blendTarget = _isSprinting ? 1f : 0.5f;

        _animationMotionSpeedBlendTime = Mathf.Lerp(
            _animationMotionSpeedBlendTime,
            blendTarget,
            Time.fixedDeltaTime * 10f);

        PlayerAnimator.SetFloat(PlayerAnimationParams.MotionSpeed, _animationMotionSpeedBlendTime);
    }

    private void OnDrawGizmos()
    {
        Vector3 _SpherePosition = FeetPoint.position;

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_SpherePosition, GroundedDetectionRadius);
    }

}
