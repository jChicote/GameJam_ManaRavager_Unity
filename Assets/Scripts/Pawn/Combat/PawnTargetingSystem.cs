using MBT;
using UnityEngine;

public interface ITargetingSystem
{
    Transform CurrentTarget { get; set; }
}

public class PawnTargetingSystem : MonoBehaviour, ITargetingSystem
{

    public Blackboard Blackboard;

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

}