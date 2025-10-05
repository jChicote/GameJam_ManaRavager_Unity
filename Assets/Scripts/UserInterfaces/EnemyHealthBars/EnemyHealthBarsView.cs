using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarsView : MonoBehaviour
{

    public GameObject HealthBarPrefab;

    [Header("References")]
    public GameObject ContentGroup;

    private readonly Dictionary<int, HealthBar> _enemyHealthBars = new();

    public void AddEnemyHealthBar(int identifier, float currentHealth, float maxHealth)
    {
        if (_enemyHealthBars.ContainsKey(identifier)) return;

        var healthBar = Instantiate(HealthBarPrefab, ContentGroup.transform)
            .GetComponent<HealthBar>();
        _enemyHealthBars.Add(identifier, healthBar);

        healthBar.SetHealth(currentHealth, maxHealth);
    }

    public void UpdateEnemyHealthBar(int identifier, float currentHealth, float maxHealth)
    {
        if (!_enemyHealthBars.TryGetValue(identifier, out var healthBar)) return;
        healthBar.SetHealth(currentHealth, maxHealth);
    }

    public void RemoveEnemyHealthBar(int identifier)
    {
        if (!_enemyHealthBars.TryGetValue(identifier, out var healthBar)) return;

        Destroy(healthBar.gameObject);
        _enemyHealthBars.Remove(identifier);
    }

}