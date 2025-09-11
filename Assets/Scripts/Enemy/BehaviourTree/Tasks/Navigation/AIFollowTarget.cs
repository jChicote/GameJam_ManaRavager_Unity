using MBT;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/AI Follow Target")]
public class AIFollowTarget : Leaf
{

    public NavMeshAgent Agent;
    public Animator Animator;
    public TransformReference FollowTarget = new TransformReference();

    private float _animationMotionSpeedBlendTime;

    public override NodeResult Execute()
    {
        Agent.SetDestination(FollowTarget.Value.position);

        var speed = Agent.velocity.magnitude;
        var blendTarget = speed > 2.5f ? 1f : 0.5f;

        _animationMotionSpeedBlendTime = Mathf.Lerp(
            _animationMotionSpeedBlendTime,
            blendTarget,
            Time.deltaTime * 10f);

        Animator.SetFloat(EnemyAnimationParams.MotionSpeed, _animationMotionSpeedBlendTime);

        return NodeResult.success;
    }

}