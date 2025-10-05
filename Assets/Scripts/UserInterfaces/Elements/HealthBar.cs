using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [Header("UI Reference")]
    public Slider HealthSlider;
    public RectTransform HealthBarRectTransform;

    [Header("Animation")]
    public float AnimationDuration = 0.25f;
    public Ease AnimationEase = Ease.OutQuad;
    public float FadeInDuration = 0.3f;

    private Tween _currentTween;
    private Tween _fadeTween;
    private CanvasGroup _canvasGroup;
    private bool _isVisible = false;

    public RectTransform RectTransform => HealthBarRectTransform;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _isVisible = false;
    }

    public void SetHealth(float currentHealth, float maxHealth)
    {
        var targetValue = Mathf.Clamp01(currentHealth / maxHealth);

        _currentTween?.Kill();
        _currentTween = HealthSlider.DOValue(targetValue, AnimationDuration)
            .SetEase(AnimationEase);

        // Fade in if not already visible
        if (!_isVisible)
        {
            _isVisible = true;
            _fadeTween?.Kill();
            _fadeTween = _canvasGroup.DOFade(1f, FadeInDuration);
        }
    }

    private void OnDestroy()
    {
        _currentTween?.Kill();
        _fadeTween?.Kill();
    }

}