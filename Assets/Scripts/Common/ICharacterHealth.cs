using System;

public interface ICharacterHealth
{
    float CurrentHealth { get; }
    float MaxHealth { get; }

    event Action OnHealthChanged;
}