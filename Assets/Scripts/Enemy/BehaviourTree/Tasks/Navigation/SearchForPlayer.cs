using MBT;
using UnityEngine;

public class SearchForPlayer : Leaf
{

    public float SearchRadius = 10f;
    public LayerMask PlayerLayer;
    public TransformReference EnemyTransform = new TransformReference();
    public TransformReference PlayerTransform = new TransformReference();

    public override NodeResult Execute()
    {
        Collider[] hits = Physics.OverlapSphere(EnemyTransform.Value.position, SearchRadius, PlayerLayer);
        if (hits.Length > 0)
        {
            PlayerTransform.Value = hits[0].transform;
            return NodeResult.success;
        }

        return NodeResult.failure;
    }

}