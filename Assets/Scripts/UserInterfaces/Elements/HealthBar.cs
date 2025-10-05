using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [Header("UI Reference")]
    public Slider HealthSlider;

    [Header("Animation")]
    public float AnimationDuration = 0.25f;
    public Ease AnimationEase = Ease.OutQuad;

    private Tween _currentTween;

    public void SetHealth(float currentHealth, float maxHealth)
    {
        float targetValue = Mathf.Clamp01(currentHealth / maxHealth);

        _currentTween?.Kill();
        _currentTween = HealthSlider.DOValue(targetValue, AnimationDuration)
            .SetEase(AnimationEase);
    }

    private void OnDestroy()
    {
        _currentTween?.Kill();
    }

}