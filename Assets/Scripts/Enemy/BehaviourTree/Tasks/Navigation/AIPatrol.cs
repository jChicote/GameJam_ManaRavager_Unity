using MBT;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/AI Patrol")]
public class AIPatrol : Leaf
{

    [Header("References")]
    public NavMeshAgent Agent;
    public Animator Animator;
    public FloatReference MaxMovementSpeed = new FloatReference();

    [Header("Settings")]
    public float PatrolMovementRadius = 10f;
    public float ArrivalThreshold = 0.5f;
    public bool ShowDebug = true;

    private bool _hasSelectedDestination;
    private Vector3 _selectedDestination = Vector3.zero;
    private float _animationMotionSpeedBlendTime;

    public override NodeResult Execute()
    {
        if (!_hasSelectedDestination)
        {
            _selectedDestination = GetRandomPointOnNavMesh();
            _hasSelectedDestination = true;
        }

        Agent.SetDestination(_selectedDestination);

        _animationMotionSpeedBlendTime = Mathf.Lerp(
            _animationMotionSpeedBlendTime,
            Agent.velocity.magnitude / MaxMovementSpeed.Value,
            Time.deltaTime * 10f);

        Animator.SetFloat(EnemyAnimationParams.MotionSpeed, _animationMotionSpeedBlendTime);

        if (!Agent.pathPending && Agent.remainingDistance <= Agent.stoppingDistance)
        {
            Animator.SetFloat(EnemyAnimationParams.MotionSpeed, 0f);
            _hasSelectedDestination = false;
            return NodeResult.success;
        }

        return NodeResult.running;
    }

    private Vector3 GetRandomPointOnNavMesh()
    {
        var randomDirection = Random.insideUnitSphere * PatrolMovementRadius + Agent.transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit navHit, PatrolMovementRadius, NavMesh.AllAreas))
            return navHit.position;

        return Agent.transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        if (!ShowDebug) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_selectedDestination, 0.4f);
    }

}