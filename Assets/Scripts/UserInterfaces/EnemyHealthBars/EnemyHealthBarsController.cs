using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarsController : MonoBehaviour
{

    public UIEventHub EventHub;
    public EnemyHealthBarsView View;

    private const float TOLERANCE = 0.01f;

    private readonly Dictionary<int, CreateEnemyHealthBarRequest> _activeEnemyHealthBars = new();

    private void Awake()
    {
        EventHub.RegisterEvent(
            EnemyHealthBarsGUIActions.AddEnemyHealthBar,
            request => this.AddEnemyHealthBar(request as CreateEnemyHealthBarRequest));

        EventHub.RegisterEvent(
            EnemyHealthBarsGUIActions.UpdateEnemyHealthBar,
            identifier => this.UpdateEnemyHealthBar((int)identifier));

        EventHub.RegisterEvent(
            EnemyHealthBarsGUIActions.RemoveEnemyHealthBar,
            identifier => this.RemoveEnemyHealthBar((int)identifier));
    }

    private void Update()
    {
        foreach (var identifier in _activeEnemyHealthBars.Keys)
            UpdateEnemyHealthBar(identifier);
    }

    public void AddEnemyHealthBar(CreateEnemyHealthBarRequest request)
    {
        _activeEnemyHealthBars.Add(request.Identifier, request);
        View.AddEnemyHealthBar(request.Identifier, request.EnemyHealth.CurrentHealth, request.EnemyHealth.MaxHealth);
    }

    public void UpdateEnemyHealthBar(int identifier)
    {
        var _characterHealth = _activeEnemyHealthBars[identifier];
        if (Math.Abs(_characterHealth.EnemyHealth.CurrentHealth - _characterHealth.EnemyHealth.MaxHealth) < TOLERANCE)
            return;

        View.UpdateEnemyHealthBar(
            identifier,
            _characterHealth.EnemyHealth.CurrentHealth,
            _characterHealth.EnemyHealth.MaxHealth,
            _characterHealth.EnemyMarkerPoint.MarkerPosition);
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
    public int Identifier { get; set; }
    public ICharacterHealth EnemyHealth { get; set; }
    public ICharacterHealthMarkerPoint EnemyMarkerPoint { get; set; }
}

public class EnemyHealthBarsGUIActions
{
    public const string AddEnemyHealthBar = "AddEnemyHealthBar";
    public const string UpdateEnemyHealthBar = "UpdateEnemyHealthBar";
    public const string RemoveEnemyHealthBar = "RemoveEnemyHealthBar";
}