using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Conditions/Can Summon Group")]
public class CanSummonGroup : Condition
{

    public EnemyManaHandler ManaHandler;
    public EnemySummonerHandler SummonerHandler;
    public float Cooldown = 3;

    private float _nextAllowedTime = 0f;

    public override bool Check()
    {
        if (ManaHandler.CurrentMana < SummonerHandler.PawnSpawnCost)
            return false;

        if (Time.time < _nextAllowedTime)
            return false;

        _nextAllowedTime = Time.time + Cooldown;
        return true;
    }

}