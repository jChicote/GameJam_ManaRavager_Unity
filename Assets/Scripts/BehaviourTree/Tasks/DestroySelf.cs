using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Destroy Self")]
public class DestroySelf : Leaf
{

    public override NodeResult Execute()
    {
        var rootGameObject = this.transform.root.gameObject;

        Object.Destroy(rootGameObject);
        return NodeResult.success;
    }

}