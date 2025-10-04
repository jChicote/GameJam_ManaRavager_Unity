using MBT;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Approach And Stop At Distance From Target")]
public class ApproachAndStopAtDistanceFromTarget : Leaf
{

    [Header("References")]
    public NavMeshAgent Agent;
    public Animator Animator;
    public TransformReference TargetTransform = new TransformReference();
    public FloatReference MaxMovementSpeed = new FloatReference();

    [Header("Settings")]
    public float DesiredDistance = 3f;
    public float ErrorTolerance = 0.5f;

    private float _animationMotionSpeedBlendTime;

    public override NodeResult Execute()
    {
        var direction = transform.position - TargetTransform.Value.position;
        var distance = direction.magnitude;

        if (Mathf.Abs(distance - DesiredDistance) <= ErrorTolerance)
        {
            Agent.isStopped = true;
            Animator.SetFloat(EnemyAnimationParams.MotionSpeed, 0f);
            return NodeResult.success;
        }

        var desiredPosition = TargetTransform.Value.position + direction.normalized * DesiredDistance;

        Agent.speed = MaxMovementSpeed.Value;
        Agent.isStopped = false;
        Agent.SetDestination(desiredPosition);

        _animationMotionSpeedBlendTime = Mathf.Lerp(
            _animationMotionSpeedBlendTime,
            Agent.velocity.magnitude / MaxMovementSpeed.Value,
            Time.deltaTime * 10f);

        Animator.SetFloat(EnemyAnimationParams.MotionSpeed, _animationMotionSpeedBlendTime);

        return NodeResult.running;
    }

}