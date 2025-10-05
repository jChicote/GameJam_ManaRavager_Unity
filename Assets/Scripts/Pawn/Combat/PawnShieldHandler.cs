using MBT;
using UnityEngine;

public class PawnShieldHandler : MonoBehaviour
{

    public Animator PawnAnimator;
    public Blackboard BlackBoard;
    public int MaxShieldHits;

    private IntVariable _shieldHealthBlackBoardVariable;

    private bool _isShieldDrawn;

    public bool IsShielding => _isShieldDrawn;

    private void Start()
        => _shieldHealthBlackBoardVariable = BlackBoard.GetVariable<IntVariable>("ShieldHits");

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

    public void TriggerShieldImpact()
    {
        if (!_isShieldDrawn) return;

        PawnAnimator.SetTrigger(EnemyAnimationParams.Hit);
        _shieldHealthBlackBoardVariable.Value++;

        if (_shieldHealthBlackBoardVariable.Value > MaxShieldHits)
            WithdrawShield();
    }

    public void WithdrawShield()
    {
        PawnAnimator.SetTrigger(EnemyAnimationParams.SheathShield);
        PawnAnimator.SetBool(EnemyAnimationParams.IsShieldDrawn, false);
        _isShieldDrawn = false;
    }

}