using MBT;
using System;
using UnityEngine;

public class PawnHealthSystem : MonoBehaviour, ICharacterHealth, IDamageableHandler
{

    public Animator Animator;
    public PawnShieldHandler ShieldHandler;
    public Blackboard BlackBoard;
    public float MaxHealth = 100f;

    private FloatVariable _currentHealthBlackBoardVariable;
    private BoolVariable _isAttackedBlackboardVariable;
    private FloatVariable _maxHealthBlackBoardVariable;

    private float _currentHealth;

    public event Action OnHealthChanged;

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

    private void Start()
    {
        _currentHealthBlackBoardVariable = BlackBoard.GetVariable<FloatVariable>("CurrentHealth");
        _isAttackedBlackboardVariable = BlackBoard.GetVariable<BoolVariable>("IsAttacked");
        _maxHealthBlackBoardVariable = BlackBoard.GetVariable<FloatVariable>("MaxHealth");

        CurrentHealth = MaxHealth;
        _currentHealthBlackBoardVariable.Value = CurrentHealth;
        _maxHealthBlackBoardVariable.Value = MaxHealth;
    }

    public void AddDamage(float damageAmount)
    {
        if (ShieldHandler.IsShielding)
        {
            ShieldHandler.TriggerShieldImpact();
            return;
        }

        CurrentHealth -= damageAmount;

        _isAttackedBlackboardVariable.Value = true;
    }
}