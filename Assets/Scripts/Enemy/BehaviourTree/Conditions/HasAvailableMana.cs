using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Conditions/Has Available Mana")]
public class HasAvailableMana : Condition
{

    public EnemyManaHandler ManaHandler;

    public override bool Check()
    {
        if (ManaHandler.CurrentMana > 0)
            return true;

        return false;
    }

}