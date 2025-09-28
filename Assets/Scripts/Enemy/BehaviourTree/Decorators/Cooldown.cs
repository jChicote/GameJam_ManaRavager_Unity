using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Decorators/Custom Cooldown")]
public class Cooldown : Decorator
{

    public float CooldownTime = 5f;
    private float lastExecutionTime = -Mathf.Infinity;

    public override NodeResult Execute()
    {
        if (!TryGetChild(out Node node))
        {
            return NodeResult.failure;
        }
        if (node.status == Status.Success || node.status == Status.Failure)
        {
            return NodeResult.From(node.status);
        }
        if (Time.time - lastExecutionTime < CooldownTime)
        {
            return NodeResult.failure;
        }
        lastExecutionTime = Time.time;
        return node.runningNodeResult;
    }
}