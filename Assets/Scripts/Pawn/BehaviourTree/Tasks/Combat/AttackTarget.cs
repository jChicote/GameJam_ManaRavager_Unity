using MBT;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Attack Target")]
public class AttackTarget : Leaf
{

    public NavMeshAgent Agent;
    public Animator Animator;
    public TransformReference TargetTransform = new TransformReference();
    public TransformReference SelfTransform = new TransformReference();
    public FloatReference MovementSpeed = new FloatReference();

    public PawnSwordHandler SwordHandler;

    public float DesiredDistance = 0.5f;
    public float ErrorTolerance = 0.25f;

    private float _animationMotionSpeedBlendTime;

    public override NodeResult Execute()
    {
        var direction = transform.position - TargetTransform.Value.position;
        var distance = direction.magnitude;

        //if (distance > DesiredDistance + ErrorTolerance)
        //{
        //    SelfTransform.Value.position = Vector3.MoveTowards(
        //        SelfTransform.Value.position,
        //        TargetTransform.Value.position,
        //        MovementSpeed.Value * Time.deltaTime);

        //    // Move to target
        //    _animationMotionSpeedBlendTime = Mathf.Lerp(
        //        _animationMotionSpeedBlendTime,
        //        Agent.velocity.magnitude / MovementSpeed.Value,
        //        Time.deltaTime * 10f);

        //    Animator.SetFloat(EnemyAnimationParams.MotionSpeed, _animationMotionSpeedBlendTime);

        //    return NodeResult.success;
        //}

        if (Mathf.Abs(distance - DesiredDistance) <= ErrorTolerance)
        {
            SwordHandler.Attack();
            return NodeResult.success;
        }

        return NodeResult.failure;
    }

}