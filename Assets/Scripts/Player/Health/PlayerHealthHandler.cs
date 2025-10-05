using System;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour, ICharacterHealth, IDamageableHandler
{

    public float MaxHealth = 100f;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

    float ICharacterHealth.MaxHealth => MaxHealth;

    public event Action OnHealthChanged;

    private void Start()
    {
        _currentHealth = MaxHealth;
        OnHealthChanged?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == GameLayers.Player) return;

        if (other.gameObject.layer == GameLayers.Enemy
            && other.gameObject.CompareTag(GameTags.HitBox))
        {
        }
    }

    private void OnBecameVisible()
        => OnHealthChanged?.Invoke();

    public void AddDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        OnHealthChanged?.Invoke();
    }

}