using MBT;
using System;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Scan For Target")]
public class ScanForTarget : Leaf
{

    [Header("References")]
    public TransformReference TargetTransform = new TransformReference();
    public TransformReference SelfTransform = new TransformReference();
    public BoolReference IsEngaged = new BoolReference();

    [Header("Search Settings")]
    public float ViewLengthRadius = 10f;
    public float ViewAngle = 90f;
    public LayerMask TargetMask;
    public LayerMask ObstacleMask;
    public float ScanTimeLength = 3f;

    [Header("Debug")]
    public bool ShowDebug = true;

    private float _scanTimer;

    public override NodeResult Execute()
    {
        var directionToTarget = (TargetTransform.Value.position - SelfTransform.Value.position).normalized;
        var distanceToTarget = Vector3.Distance(SelfTransform.Value.position, TargetTransform.Value.position);

        var angle = Vector3.Angle(SelfTransform.Value.forward, directionToTarget);
        var isWithinViewAngle = angle <= ViewAngle / 2f;
        var isWithinViewRadius = distanceToTarget <= ViewLengthRadius;

        if (_scanTimer > ScanTimeLength)
        {
            _scanTimer = 0f;
            return NodeResult.success;
        }

        if (isWithinViewRadius
            && isWithinViewAngle
            && !Physics.Raycast(SelfTransform.Value.position + Vector3.forward * 1.5f, directionToTarget, distanceToTarget, TargetMask))
        {
            _scanTimer = 0f;
            IsEngaged.Value = true;
            return NodeResult.success;
        }

        _scanTimer += Time.deltaTime;
        return NodeResult.running;
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

}