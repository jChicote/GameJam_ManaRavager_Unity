using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Enemy Draw Weapon")]
public class Enemy_DrawWeapon : Leaf
{

    public Animator Animator;
    public EnemySwordHandler SwordHandler;

    public override NodeResult Execute()
    {
        if (Animator.GetBool(EnemyAnimationParams.IsSwordDrawn))
            return NodeResult.success;

        SwordHandler.DrawSword();
        return NodeResult.success;
    }

}