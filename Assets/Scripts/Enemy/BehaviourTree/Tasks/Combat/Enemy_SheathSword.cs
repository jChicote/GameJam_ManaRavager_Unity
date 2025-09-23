using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Enemy Sheath Weapon")]
public class Enemy_SheathWeapon : Leaf
{

    public Animator Animator;
    public EnemySwordHandler SwordHandler;

    public override NodeResult Execute()
    {
        if (!Animator.GetBool(EnemyAnimationParams.IsSwordDrawn))
            return NodeResult.success;

        SwordHandler.SheathSword();
        return NodeResult.success;
    }

}