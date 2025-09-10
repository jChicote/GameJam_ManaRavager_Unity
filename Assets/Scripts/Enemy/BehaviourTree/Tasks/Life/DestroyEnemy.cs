using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Destroy Enemy")]
public class DestroyEnemy : Leaf
{

    public GameObjectReference EnemyGameObject = new GameObjectReference();

    public override NodeResult Execute()
    {
        Destroy(EnemyGameObject.Value);
        return NodeResult.success;
    }

}