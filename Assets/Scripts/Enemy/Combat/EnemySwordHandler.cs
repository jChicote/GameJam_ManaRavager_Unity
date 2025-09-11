using UnityEngine;

public class EnemySwordHandler : MonoBehaviour
{

    private bool _isAttackInProgress;

    private void Start()
    {
    }

    public void AnimationEvent_EquipSword()
    {
    }

    public void AnimationEvent_SheathSword()
    {
    }

    public void AnimationEvent_AttackStart()
        => _isAttackInProgress = true;

    public void AnimationEvent_AttackEnd()
        => _isAttackInProgress = false;

}