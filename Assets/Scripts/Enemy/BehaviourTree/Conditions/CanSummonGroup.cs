using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Conditions/Can Summon Group")]
public class CanSummonGroup : Condition
{

    public float Cooldown = 3;

    private float _nextAllowedTime = 0f;


    public override bool Check()
    {
        // Check whether owner has enough mana to spare

        // Check whether next pawn group can be summoned after cooldown
        if (Time.time < _nextAllowedTime)
            return false;

        _nextAllowedTime = Time.time + Cooldown;
        return true;
    }

}