using UnityEngine;

public class PawnSwordHandler : MonoBehaviour
{

    public Animator PawnAnimator;
    public PawnCharacterSockets CharacterSockets;
    public GameObject SwordAssetPrefab;

    private int _attackIndex = 0;
    private GameObject _currentSword;
    private bool _isSwordDrawn = false;
    private bool _isAttackInProgress;

    private void Start()
    {
        EquipSword();
    }

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
        PawnAnimator.SetInteger(EnemyAnimationParams.SetAttackSelection, _attackIndex);
        PawnAnimator.SetTrigger(EnemyAnimationParams.Attack);
    }

    public void EquipSword()
    {
        _currentSword = Instantiate(SwordAssetPrefab, CharacterSockets.SwordHolderSocket);
        _currentSword.layer = this.gameObject.layer;
    }

    public void DrawSword()
    {
        PawnAnimator.SetTrigger(EnemyAnimationParams.DrawSword);
        PawnAnimator.SetBool(EnemyAnimationParams.IsSwordDrawn, true);
        _isSwordDrawn = true;
    }

    public void SheathSword()
    {
        PawnAnimator.SetTrigger(EnemyAnimationParams.SheathSword);
        PawnAnimator.SetBool(EnemyAnimationParams.IsSwordDrawn, false);
        _isSwordDrawn = false;
    }

}