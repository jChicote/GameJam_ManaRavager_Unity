using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHudView : MonoBehaviour
{

    public GameObject ContentGroup;
    public TMP_Text ComboText;
    public TMP_Text TotalScoreText;
    public Slider HealthBarSlider;
    public Slider ManaBarSlider;

    public void UpdateHealthBar(float currentHealth, float maxHealth)
        => HealthBarSlider.value = currentHealth / maxHealth;

    public void UpdateManaBar(float manaPercentage)
        => ManaBarSlider.value = manaPercentage;

    public void UpdateCombo(int combo)
        => ComboText.text = combo.ToString();

    public void UpdateTotalScore(int totalScore)
        => TotalScoreText.text = totalScore.ToString();

}