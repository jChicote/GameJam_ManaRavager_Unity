using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Mana Push")]
public class ManaPush : Leaf
{

    [Header("References")]
    public Animator Animator;

    public override NodeResult Execute()
    {
        Animator.SetTrigger(EnemyAnimationParams.ManaPush);
        return NodeResult.success;
    }

}