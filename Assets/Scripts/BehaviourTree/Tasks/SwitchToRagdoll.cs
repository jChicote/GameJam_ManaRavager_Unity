using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Switch to Ragdoll")]
public class SwitchToRagdoll : Leaf
{

    public AnimationToRagdollHandler RagdollHandler;

    public override NodeResult Execute()
    {
        RagdollHandler.ToggleRagdoll(true);
        return NodeResult.success;
    }

}