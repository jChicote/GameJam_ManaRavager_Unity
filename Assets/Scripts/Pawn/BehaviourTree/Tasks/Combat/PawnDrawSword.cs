using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Pawn Draw Sword")]
public class PawnDrawSword : Leaf
{

    public Animator Animator;
    public PawnSwordHandler SwordHandler;

    public override NodeResult Execute()
    {
        if (Animator.GetBool(EnemyAnimationParams.IsSwordDrawn))
            return NodeResult.success;

        SwordHandler.DrawSword();
        return NodeResult.success;
    }

}