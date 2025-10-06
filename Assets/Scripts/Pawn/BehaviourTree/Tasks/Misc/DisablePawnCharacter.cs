using MBT;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode(name = "Tasks/Disable Pawn Character")]
public class DisablePawnCharacter : Leaf
{

    public Animator PawnAnimator;
    public CharacterController CharacterController;
    public NavMeshAgent NavMeshAgent;

    public override NodeResult Execute()
    {
        PawnAnimator.enabled = false;
        CharacterController.enabled = false;
        NavMeshAgent.enabled = false;

        var uiEventHub = GameManager.Instance.UIEventHub;
        uiEventHub.TriggerEvent(
            EnemyHealthBarsGUIActions.RemoveEnemyHealthBar,
            CharacterController.gameObject.GetInstanceID());

        return NodeResult.success;
    }

}