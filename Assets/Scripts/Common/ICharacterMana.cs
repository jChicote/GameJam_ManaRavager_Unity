using System;

public interface ICharacterMana
{
    float RemainingManaPercentage { get; }

    event Action OnManaChanged;
}