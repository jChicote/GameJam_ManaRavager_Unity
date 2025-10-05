using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Wait And Face Target")]
public class WaitAndFaceTarget : Leaf
{

    public TransformReference FollowTarget = new TransformReference();
    public TransformReference SelfTransform = new TransformReference();

    public float RotationSpeed = 10f;
    public float WaitTime = 1f;

    private float _waitTimer;

    public override void OnEnter()
        => _waitTimer = WaitTime;

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

        _waitTimer -= Time.deltaTime;
        if (_waitTimer <= 0f)
            return NodeResult.success;

        return NodeResult.running;
    }

}