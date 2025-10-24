using System.Collections;
using UnityEngine;

public class AnimateActionState : CombatState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(AnimateCo());
    }

    private IEnumerator AnimateCo()
    {
        //Animator animator = currentCharacter.gameObject.GetComponent<Animator>();
        currentCharacter.animator.SetTrigger(actionManager.GetActionAnimationTrigger());
        yield return new WaitForSeconds(2);
        owner.ChangeState<PerformActionState>();
    }
}
