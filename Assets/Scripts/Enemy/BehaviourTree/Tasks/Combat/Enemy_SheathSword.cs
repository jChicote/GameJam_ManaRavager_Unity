using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Enemy Sheath Weapon")]
public class Enemy_SheathWeapon : Leaf
{

    public Animator Animator;

    public override NodeResult Execute()
    {
        if (!Animator.GetBool(EnemyAnimationParams.IsSwordDrawn))
            return NodeResult.success;

        Animator.SetTrigger(EnemyAnimationParams.DrawSword);
        Animator.SetBool(EnemyAnimationParams.IsSwordDrawn, false);
        return NodeResult.success;
    }

}