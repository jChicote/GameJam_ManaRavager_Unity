using UnityEngine;

public class PlayerAnimationParams
{

    public static readonly int IsGrounded = Animator.StringToHash("isGrounded");
    public static readonly int PlayerJump = Animator.StringToHash("canJump");
    public static readonly int PlayerFreeFall = Animator.StringToHash("isFreeFall");

}