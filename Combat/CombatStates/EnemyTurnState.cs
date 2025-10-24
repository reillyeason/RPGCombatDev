using JetBrains.Annotations;
using System;
using System.Collections;
using UnityEngine;

public class EnemyTurnState : CombatState
{
    public override void Enter()
    {
        base.Enter();

        StartCoroutine(ChooseAction(1));
    }

    private IEnumerator ChooseAction(int delay)
    {
        // choose random ability
        Debug.Log($"Current enemy is: {currentCharacter}");
        Ability abilityToUse = owner.enemyAI.ChooseRandomAbility(currentCharacter);

        actionManager.QueueAction(abilityToUse);

        Character target = owner.enemyAI.SelectRandomTarget(heroes);
        actionManager.SetTarget(target);

        yield return new WaitForSeconds(delay);

        Debug.Log($"{currentCharacter} targets {target} with {abilityToUse}");
        owner.ChangeState<AnimateActionState>();
        //owner.ChangeState<AdvanceTurnState>();
    }
}
