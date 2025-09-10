using UnityEngine;

public class GameHUDController : MonoBehaviour
{

    public GameHudView View;
    public GameObject PlayerInstance;

    private ICharacterHealth _playerHealth;
    private ICharacterMana _playerMana;
    private GameMetrics _gameMetrics;

    private void Start()
    {
        _playerHealth = PlayerInstance.GetComponent<ICharacterHealth>();
        _playerMana = PlayerInstance.GetComponent<ICharacterMana>();
        _gameMetrics = GameManager.Instance.GameMetrics;

        _playerHealth.OnHealthChanged += this.UpdateHealth;
        _playerMana.OnManaChanged += this.UpdateMana;
        _gameMetrics.OnTotalScoreChanged += this.UpdateTotalScore;
        _gameMetrics.OnComboHitsChanged += this.UpdateComboHits;

        // Force an update
        View.UpdateHealthBar(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);
        View.UpdateManaBar(_playerMana.RemainingManaPercentage);
    }

    private void UpdateHealth()
        => View.UpdateHealthBar(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);

    private void UpdateMana()
        => View.UpdateManaBar(_playerMana.RemainingManaPercentage);

    private void UpdateTotalScore(int totalScore)
        => View.UpdateTotalScore(totalScore);

    private void UpdateComboHits(int combo)
        => View.UpdateCombo(combo);

}