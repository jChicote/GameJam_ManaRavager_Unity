using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Enemy Sheath Weapon")]
public class Enemy_SheathWeapon : Leaf
{

    public Animator Animator;

    public override NodeResult Execute()
    {
        Animator.SetTrigger(EnemyAnimationParams.DrawSword);
        return NodeResult.success;
    }

}