using MBT;
using System;
using UnityEngine;

public class EnemyAgentTargetingHandler : MonoBehaviour
{

    [SerializeField] private Transform FollowTarget;
    public Blackboard Blackboard;

    [Header("Search Settings")]
    public float ViewLengthRadius = 10f;
    public float ViewLockRadius = 16f;
    public float ViewAngle = 90f;
    public LayerMask TargetMask;
    public LayerMask ObstacleMask;
    public float ViewLockExitTimeLength = 3f;

    [Header("Debug")]
    public bool ShowDebug = true;

    private BoolVariable _isEngaged;
    private float _currentLastTimeSeen;

    private void Start()
    {
        _isEngaged = Blackboard.GetVariable<BoolVariable>("IsEngaged");
    }

    private void Update()
    {
        var directionToTarget = (FollowTarget.position - transform.position).normalized;
        var distanceToTarget = Vector3.Distance(transform.position, FollowTarget.position);

        if (_currentLastTimeSeen > ViewLockExitTimeLength)
        {
            _currentLastTimeSeen = 0f;
            _isEngaged.Value = false;
            return;
        }

        if (distanceToTarget > ViewLengthRadius)
        {
            _currentLastTimeSeen += Time.deltaTime;
            return;
        }
        else
            _currentLastTimeSeen = 0f;

        var angle = Vector3.Angle(transform.forward, directionToTarget);
        var isWithinViewAngle = angle <= ViewAngle / 2f;
        var isWithinViewRadius = distanceToTarget <= ViewLengthRadius;

        if (isWithinViewRadius
            && isWithinViewAngle
            && !Physics.Raycast(transform.position + Vector3.forward * 1.5f, directionToTarget, distanceToTarget, TargetMask))
            _isEngaged.Value = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (!ShowDebug) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ViewLengthRadius);

        var directionFromAngleAction = new Func<float, Vector3>((float angleInDegrees) =>
        {
            float rad = (transform.eulerAngles.y + angleInDegrees) * Mathf.Deg2Rad;
            return new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad));
        });

        var leftBoundary = directionFromAngleAction(-ViewAngle / 2f);
        var rightBoundary = directionFromAngleAction(ViewAngle / 2f);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary * ViewLengthRadius);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary * ViewLengthRadius);
    }

    private void OnDrawGizmos()
    {
        // Draw to Target
        var distanceToTarget = Vector3.Distance(transform.position, FollowTarget.position);
        Gizmos.color = distanceToTarget > ViewLengthRadius ? Color.red : Color.green;
        Gizmos.DrawLine(transform.position, FollowTarget.position);
    }

}