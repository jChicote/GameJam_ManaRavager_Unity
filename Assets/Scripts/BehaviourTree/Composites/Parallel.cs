using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Composites/Parallel")]
public class Parallel : Node
{

    public override NodeResult Execute()
    {
        bool anyRunning = false;
        bool anyFailure = false;

        foreach (var child in children)
        {
            var result = child.Execute();
            if (result == NodeResult.running)
                anyRunning = true;
            else if (result == NodeResult.failure)
                anyFailure = true;
        }

        if (anyFailure)
            return NodeResult.failure;
        if (anyRunning)
            return NodeResult.running;
        return NodeResult.success;
    }

    public override void AddChild(Node node) => children.Add(node);
    public override void RemoveChild(Node node) => children.Remove(node);

}