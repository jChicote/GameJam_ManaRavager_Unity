using System;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour, ICharacterHealth, IDamageableHandler
{

    public float MaxHealth = 100f;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

    float ICharacterHealth.MaxHealth => MaxHealth;

    private void Start()
        => _currentHealth = MaxHealth;

    public event Action OnHealthChanged;

    public void AddDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        OnHealthChanged?.Invoke();
    }
}