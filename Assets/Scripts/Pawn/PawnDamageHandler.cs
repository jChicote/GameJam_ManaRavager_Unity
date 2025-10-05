using UnityEngine;

public class PawnDamageHandler : MonoBehaviour, IDamageableHandler
{

    public PawnHealthSystem HealthSystem;
    public PawnShieldHandler ShieldHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == gameObject.layer) return;

        if (other.gameObject.CompareTag(GameTags.HitBox))
        {
            var damageSender = other.gameObject.GetComponent<IDamageSender>();
            this.AddDamage(damageSender.Damage);
        }
    }

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