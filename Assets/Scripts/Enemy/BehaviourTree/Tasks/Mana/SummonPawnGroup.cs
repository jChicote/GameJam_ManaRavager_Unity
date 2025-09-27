using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Summon Pawn Group")]
public class SummonPawnGroup : Leaf
{

    public EnemySummonerHandler SummonerHandler;

    public override NodeResult Execute()
    {
        SummonerHandler.SummonPawns();
        return NodeResult.success;
    }

}