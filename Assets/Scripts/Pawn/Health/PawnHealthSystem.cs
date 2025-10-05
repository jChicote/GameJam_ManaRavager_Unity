using MBT;
using System;
using UnityEngine;

public class PawnHealthSystem : MonoBehaviour, ICharacterHealth, ICharacterHealthMarkerPoint
{

    public Blackboard BlackBoard;
    public Transform HealthMarkerPoint;
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

    public Vector3 MarkerPosition => HealthMarkerPoint.position;

    float ICharacterHealth.MaxHealth => MaxHealth;

    private void Start()
    {
        _currentHealthBlackBoardVariable = BlackBoard.GetVariable<FloatVariable>("CurrentHealth");
        _isAttackedBlackboardVariable = BlackBoard.GetVariable<BoolVariable>("IsAttacked");
        _maxHealthBlackBoardVariable = BlackBoard.GetVariable<FloatVariable>("MaxHealth");

        CurrentHealth = MaxHealth;
        _currentHealthBlackBoardVariable.Value = CurrentHealth;
        _maxHealthBlackBoardVariable.Value = MaxHealth;

        // Add its own UI health bar
        var eventHub = GameManager.Instance.UIEventHub;
        var request = new CreateEnemyHealthBarRequest
        {
            Identifier = this.gameObject.GetInstanceID(),
            EnemyHealth = this,
            EnemyMarkerPoint = this
        };
        eventHub.TriggerEvent(EnemyHealthBarsGUIActions.AddEnemyHealthBar, request);
    }

    public void AddDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        _isAttackedBlackboardVariable.Value = true;
    }

}