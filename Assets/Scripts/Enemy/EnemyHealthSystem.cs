using MBT;
using System;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour, ICharacterHealth, IDamageableHandler
{

    public Blackboard BlackBoard;
    public float MaxHealth = 100f;

    private FloatVariable _currentHealthBlackBoardVariable;
    private FloatVariable _maxHealthBlackBoardVariable;

    private float _currentHealth;

    public float CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            _currentHealthBlackBoardVariable.Value = _currentHealth;
            OnHealthChanged?.Invoke();
        }
    }

    float ICharacterHealth.MaxHealth => MaxHealth;

    public event Action OnHealthChanged;

    private void Start()
    {
        _currentHealthBlackBoardVariable = BlackBoard.GetVariable<FloatVariable>("CurrentHealth");
        _maxHealthBlackBoardVariable = BlackBoard.GetVariable<FloatVariable>("MaxHealth");

        CurrentHealth = MaxHealth;
        _maxHealthBlackBoardVariable.Value = MaxHealth;
    }

    public void AddDamage(float damageAmount)
        => CurrentHealth -= damageAmount;

}
