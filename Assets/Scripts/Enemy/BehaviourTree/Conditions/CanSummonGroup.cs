using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Conditions/Can Summon Group")]
public class CanSummonGroup : Condition
{

    public EnemyManaHandler ManaHandler;
    public EnemySummonerHandler SummonerHandler;

    public override bool Check()
    {
        if (ManaHandler.CurrentMana < SummonerHandler.PawnSpawnCost)
            return false;

        return true;
    }

}