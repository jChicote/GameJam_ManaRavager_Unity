using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Pawn Draw Shield")]
public class DrawShield : Leaf
{

    public Animator Animator;

    public override NodeResult Execute()
    {
        if (Animator.GetBool(EnemyAnimationParams.IsShieldDrawn))
            return NodeResult.success;

        return NodeResult.success;
    }

}