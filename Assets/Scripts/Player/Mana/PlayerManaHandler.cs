using System;
using UnityEngine;

public class PlayerManaHandler : MonoBehaviour, ICharacterMana
{

    public float MaxMana = 100f;

    private float _currentMana;

    public float RemainingManaPercentage => _currentMana / MaxMana;

    public event Action OnManaChanged;

    private void Start()
    {
        _currentMana = MaxMana;
        OnManaChanged?.Invoke();
    }

    public void ConsumeMana(float amount)
    {
        _currentMana -= amount;
        if (_currentMana < 0) _currentMana = 0;

        OnManaChanged?.Invoke();
    }

}