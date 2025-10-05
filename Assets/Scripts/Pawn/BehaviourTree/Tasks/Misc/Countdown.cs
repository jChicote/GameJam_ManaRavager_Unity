using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Countdown")]
public class Countdown : Leaf
{

    public float Duration = 1f;

    private float _endTime;

    public override void OnEnter()
        => _endTime = Time.time + Duration;

    public override NodeResult Execute()
        => Time.time >= _endTime ? NodeResult.success : NodeResult.failure;

}