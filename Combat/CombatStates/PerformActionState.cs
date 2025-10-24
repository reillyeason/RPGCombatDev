using System;
using System.Collections;
using UnityEngine;

public class PerformActionState : CombatState
{
    private event Action ActionFinished;
    public override void Enter()
    {
        base.Enter();
        //StartCoroutine(AnimationDelay(currentCharacter, 2));
        actionManager.Use(currentCharacter);
        StartCoroutine(DelayAfterAction(1));
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        ActionFinished += OnAttackFinish;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        ActionFinished -= OnAttackFinish;
    }
    private void OnAttackFinish()
    {
        actionManager.Clear();
        owner.ChangeState<AdvanceTurnState>();
    }

    private IEnumerator DelayAfterAction(int delay)
    {
        yield return new WaitForSeconds(delay);

        ActionFinished?.Invoke();
    }
}
