using UnityEngine;

public class EnemyAnimationParams
{

    public static readonly int IsGrounded = Animator.StringToHash("isGrounded");
    public static readonly int IsSwordDrawn = Animator.StringToHash("IsSwordDrawn");
    public static readonly int IsShieldDrawn = Animator.StringToHash("IsShieldDrawn");
    public static readonly int Jump = Animator.StringToHash("canJump");
    public static readonly int FreeFall = Animator.StringToHash("isFreeFall");
    public static readonly int MotionSpeed = Animator.StringToHash("AnimationMotionSpeed");
    public static readonly int DrawSword = Animator.StringToHash("DrawSword");
    public static readonly int DrawShield = Animator.StringToHash("DrawShield");
    public static readonly int SheathSword = Animator.StringToHash("SheathSword");
    public static readonly int SheathShield = Animator.StringToHash("SheathShield");
    public static readonly int SetAttackSelection = Animator.StringToHash("AttackSelection");
    public static readonly int Attack = Animator.StringToHash("Attack");
    public static readonly int Summon = Animator.StringToHash("Summon");
    public static readonly int Block = Animator.StringToHash("Block");
    public static readonly int ManaPush = Animator.StringToHash("ManaPush");
    public static readonly int Hit = Animator.StringToHash("Hit");

}