using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Attack Target")]
public class AttackTarget : Leaf
{

    public TransformReference TargetTransform = new TransformReference();
    public TransformReference SelfTransform = new TransformReference();
    public FloatReference MovementSpeed = new FloatReference();

    public PawnSwordHandler SwordHandler;

    public float DesiredDistance = 0.5f;
    public float ErrorTolerance = 0.25f;

    public override NodeResult Execute()
    {
        var direction = transform.position - TargetTransform.Value.position;
        var distance = direction.magnitude;

        if (distance > DesiredDistance + ErrorTolerance)
        {
            SelfTransform.Value.position = Vector3.MoveTowards(
                SelfTransform.Value.position,
                TargetTransform.Value.position,
                MovementSpeed.Value * Time.deltaTime);
            return NodeResult.running;
        }

        if (Mathf.Abs(distance - DesiredDistance) <= ErrorTolerance)
        {
            SwordHandler.Attack();
            return NodeResult.success;
        }

        return NodeResult.failure;
    }

}