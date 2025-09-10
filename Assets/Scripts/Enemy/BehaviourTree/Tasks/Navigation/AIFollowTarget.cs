using MBT;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/AI Follow Target")]
public class AIFollowTarget : Leaf
{

    public NavMeshAgent Agent;

    public TransformReference FollowTarget = new TransformReference();

    public override NodeResult Execute()
    {
        Debug.Log("adawdw");
        Agent.SetDestination(FollowTarget.Value.position);
        return NodeResult.success;
    }

}