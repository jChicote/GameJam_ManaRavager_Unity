using UnityEngine;

public class GameHUDController : MonoBehaviour
{

    public GameHudView View;
    public GameObject PlayerInstance;

    private ICharacterHealth _playerHealth;

    private void Start()
    {
        _playerHealth = PlayerInstance.GetComponent<ICharacterHealth>();
        _playerHealth.OnHealthChanged += this.UpdateHealth;
    }

    private void UpdateHealth()
        => View.UpdateHealthBar(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);

}