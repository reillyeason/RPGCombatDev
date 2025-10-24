using System.Collections;
using UnityEngine;

public class CheckConditionsState : CombatState
{
    public override void Enter()
    {
        base.Enter();

        StartCoroutine(CheckConditionsCo());
    }

    private IEnumerator CheckConditionsCo()
    {
        yield return null;

        if (enemies.Count == 0)
        {
            owner.ChangeState<BattleWonState>();
        }
        else if (heroes.Count == 0)
        {
            owner.ChangeState<BattleLostState>();
        }
        else
        {
            // keep going
            owner.ChangeState<AdvanceTurnState>();
        }
    }
}
