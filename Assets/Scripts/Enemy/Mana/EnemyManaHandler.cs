using UnityEngine;

public class EnemyManaHandler : MonoBehaviour
{

    public float MaxMana = 100f;
    public float CurrentMana = 100f;
    public float ManaRegenRate = 5f; // Mana regenerated per second

    public bool UseMana(float amount)
    {
        if (CurrentMana >= amount)
        {
            CurrentMana -= amount;
            return true;
        }
        return false; // Not enough mana
    }

}