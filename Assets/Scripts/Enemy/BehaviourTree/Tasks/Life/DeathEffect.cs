using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Play Death Effect")]
public class DeathEffect : Leaf
{

    public GameObjectReference DeathEffectPrefab = new GameObjectReference();
    public TransformReference SpawnPoint = new TransformReference();

    public override NodeResult Execute()
    {
        Instantiate(DeathEffectPrefab.Value, SpawnPoint.Value.position, Quaternion.identity);
        return NodeResult.success;
    }

}