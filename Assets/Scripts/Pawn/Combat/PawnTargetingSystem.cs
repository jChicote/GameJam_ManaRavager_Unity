using MBT;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

public interface ITargetingSystem
{
    Transform CurrentTarget { get; set; }
}

public class PawnTargetingSystem : MonoBehaviour, ITargetingSystem
{

    public Blackboard Blackboard;
    public bool ShowDebug;

    private TransformVariable FollowTargetVariable;
    private Transform _currentTarget;

    public Transform CurrentTarget
    {
        get => _currentTarget;
        set
        {
            if (FollowTargetVariable == null)
                FollowTargetVariable = Blackboard.GetVariable<TransformVariable>("FollowTransform");

            _currentTarget = value;
            FollowTargetVariable.Value = _currentTarget;
        }
    }

    private void Start()
        => FollowTargetVariable = Blackboard.GetVariable<TransformVariable>("FollowTransform");

    public void OnDrawGizmos()
    {
        if (!ShowDebug) return;

        if (_currentTarget == null)
            return;

        Vector3 from = this.transform.position;
        Vector3 to = _currentTarget.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(from, to);

        float distance = Vector3.Distance(from, to);
        Vector3 midPoint = Vector3.Lerp(from, to, 0.5f);

        #if UNITY_EDITOR
        Handles.color = Color.white;
        Handles.Label(midPoint, $"Distance: {distance:F2}");
        #endif
    }

}