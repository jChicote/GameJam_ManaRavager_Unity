using UnityEngine;

public class EnemyAnimationParams
{

    public static readonly int IsGrounded = Animator.StringToHash("isGrounded");
    public static readonly int Jump = Animator.StringToHash("canJump");
    public static readonly int FreeFall = Animator.StringToHash("isFreeFall");
    public static readonly int MotionSpeed = Animator.StringToHash("AnimationMotionSpeed");
    public static readonly int DrawSword = Animator.StringToHash("DrawSword");
    public static readonly int SheathSword = Animator.StringToHash("SheathSword");
    public static readonly int SetAttackSelection = Animator.StringToHash("AttackSelection");
    public static readonly int Attack = Animator.StringToHash("Attack");

}