using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarsController : MonoBehaviour
{

    public UIEventHub EventHub;
    public EnemyHealthBarsView View;

    private readonly Dictionary<int, ICharacterHealth> _activeEnemyHealthBars = new();

    private void Start()
    {
        EventHub.RegisterEvent(
            "AddEnemyHealthBar",
            request => this.AddEnemyHealthBar(request as CreateEnemyHealthBarRequest));

        EventHub.RegisterEvent(
            "UpdateEnemyHealthBar",
            identifier => this.UpdateEnemyHealthBar((int)identifier));

        EventHub.RegisterEvent(
            "RemoveEnemyHealthBar",
            identifier => this.RemoveEnemyHealthBar((int)identifier));
    }

    public void AddEnemyHealthBar(CreateEnemyHealthBarRequest request)
    {
        _activeEnemyHealthBars.Add(request.Identifier, request.EnemyHealth);
        View.AddEnemyHealthBar(request.Identifier, request.EnemyHealth.CurrentHealth, request.EnemyHealth.MaxHealth);
    }

    public void UpdateEnemyHealthBar(int identifier)
    {
        var _characterHealth = _activeEnemyHealthBars[identifier];
        View.UpdateEnemyHealthBar(identifier, _characterHealth.CurrentHealth, _characterHealth.MaxHealth);
    }

    public void RemoveEnemyHealthBar(int identifier)
    {
        if (!_activeEnemyHealthBars.ContainsKey(identifier)) return;
        _activeEnemyHealthBars.Remove(identifier);
        View.RemoveEnemyHealthBar(identifier);
    }

}

public class CreateEnemyHealthBarRequest
{
    public int Identifier;
    public ICharacterHealth EnemyHealth;
}