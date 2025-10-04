using UnityEngine;

public class PawnShieldHandler : MonoBehaviour
{

    public Animator PawnAnimator;

    private bool _isShieldDrawn;

    public void AnimationEvent_EngageShield()
    {

    }

    public void AnimationEvent_WithdrawShield()
    {

    }

    public void DrawShield()
    {
        PawnAnimator.SetTrigger(EnemyAnimationParams.DrawShield);
        PawnAnimator.SetBool(EnemyAnimationParams.IsShieldDrawn, true);
        _isShieldDrawn = true;
    }

    public void WithdrawShield()
    {
        PawnAnimator.SetTrigger(EnemyAnimationParams.SheathShield);
        PawnAnimator.SetBool(EnemyAnimationParams.IsShieldDrawn, false);
        _isShieldDrawn = false;
    }

}