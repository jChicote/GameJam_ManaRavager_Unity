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
    private float _maxSpeed;

    private void Start()
        => _maxSpeed = Agent.speed;

    public override NodeResult Execute()
    {
        Agent.SetDestination(FollowTarget.Value.position);

        var speed = Agent.velocity.magnitude;

        _animationMotionSpeedBlendTime = Mathf.Lerp(
            _animationMotionSpeedBlendTime,
            speed /_maxSpeed,
            Time.deltaTime * 10f);

        Animator.SetFloat(EnemyAnimationParams.MotionSpeed, _animationMotionSpeedBlendTime);

        return NodeResult.success;
    }

}