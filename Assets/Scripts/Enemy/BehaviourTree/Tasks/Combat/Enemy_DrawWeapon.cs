using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Enemy Draw Weapon")]
public class Enemy_DrawWeapon : Leaf
{

    public Animator Animator;

    public override NodeResult Execute()
    {
        if (Animator.GetBool(EnemyAnimationParams.IsSwordDrawn))
            return NodeResult.success;

        Animator.SetTrigger(EnemyAnimationParams.DrawSword);
        Animator.SetBool(EnemyAnimationParams.IsSwordDrawn, true);
        return NodeResult.success;
    }

}