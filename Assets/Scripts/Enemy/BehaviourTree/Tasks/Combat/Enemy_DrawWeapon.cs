using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Enemy Draw Weapon")]
public class Enemy_DrawWeapon : Leaf
{

    public Animator Animator;

    public override NodeResult Execute()
    {
        // Animator.SetTrigger(DrawWeaponTriggerName);
        return NodeResult.success;
    }

}