using UnityEngine;

public class PawnDamageHandler : MonoBehaviour, IDamageableHandler
{

    public PawnHealthSystem HealthSystem;
    public PawnShieldHandler ShieldHandler;

    public void AddDamage(float damageAmount)
    {
        if (ShieldHandler.IsShielding)
        {
            ShieldHandler.TriggerShieldImpact();
            return;
        }

        HealthSystem.AddDamage(damageAmount);
    }

}