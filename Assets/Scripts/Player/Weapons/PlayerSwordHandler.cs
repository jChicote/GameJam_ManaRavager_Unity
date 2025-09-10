using UnityEngine;

public class PlayerSwordHandler : MonoBehaviour
{

    public Animator PlayerAnimator;
    public PlayerCharacterSockets CharacterSockets;
    public GameObject SwordAssetPrefab;

    private int _attackIndex = 0;
    private GameObject _currentSword;
    private bool _isSwordDrawn = false;
    private bool _isAttackInProgress;

    public void AnimationEvent_EquipSword()
    {
        _currentSword.transform.SetParent(CharacterSockets.RightHandSocket);
        _currentSword.transform.localPosition = Vector3.zero;
        _currentSword.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void AnimationEvent_SheathSword()
    {
        _currentSword.transform.SetParent(CharacterSockets.SwordHolderSocket);
        _currentSword.transform.localPosition = Vector3.zero;
        _currentSword.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void AnimationEvent_AttackStart()
        => _isAttackInProgress = true;

    public void AnimationEvent_AttackEnd()
        => _isAttackInProgress = false;

    public void Attack()
    {
        if (_currentSword == null || !_isSwordDrawn || _isAttackInProgress) return;

        _attackIndex = 1 - _attackIndex;
        PlayerAnimator.SetInteger(PlayerAnimationParams.SetAttackSelection, _attackIndex);
        PlayerAnimator.SetTrigger(PlayerAnimationParams.Attack);
    }

    public void EquipSword()
    {
        _currentSword = Instantiate(SwordAssetPrefab, CharacterSockets.SwordHolderSocket);
    }

    public void ToggleSwordHandling()
    {
        if (_currentSword == null) return;

        _isSwordDrawn = !_isSwordDrawn;

        if (_isSwordDrawn)
            DrawSword();
        else
            SheathSword();
    }

    private void DrawSword()
    {
        PlayerAnimator.SetTrigger(PlayerAnimationParams.DrawSword);
    }

    private void SheathSword()
    {
        PlayerAnimator.SetTrigger(PlayerAnimationParams.SheathSword);
    }

}