using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Attack Target")]
public class AttackTarget : Leaf
{

    public TransformReference TargetTransform = new TransformReference();
    public TransformReference SelfTransform = new TransformReference();

    public PawnSwordHandler SwordHandler;

    public float DesiredDistance = 2.5f;
    public float ErrorTolerance = 0.5f;

    public override NodeResult Execute()
    {
        var direction = transform.position - TargetTransform.Value.position;
        var distance = direction.magnitude;

        if (Mathf.Abs(distance - DesiredDistance) <= ErrorTolerance)
        {
            SwordHandler.Attack();
            return NodeResult.success;
        }

        return NodeResult.failure;
    }

}