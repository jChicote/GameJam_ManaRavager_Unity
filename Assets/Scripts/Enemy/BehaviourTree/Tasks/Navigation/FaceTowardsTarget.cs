using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Face Towards Target")]
public class FaceTowardsTarget : Leaf
{

    public TransformReference FollowTarget = new TransformReference();
    public TransformReference SelfTransform = new TransformReference();

    public float RotationSpeed = 10f;

    public override NodeResult Execute()
    {
        var direction = FollowTarget.Value.position - transform.position;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            SelfTransform.Value.rotation = Quaternion.Slerp(
                SelfTransform.Value.rotation,
                targetRotation,
                Time.deltaTime * RotationSpeed);
        }

        return NodeResult.success;
    }

}