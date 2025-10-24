using System.Collections;
using UnityEngine;

public class AdvanceTurnState : CombatState
{
    public override void Enter()
    {
        base.Enter();

        if ( owner.turnQueue.Count == 0)
        {
            StartCoroutine(ResetQueue());
        }
        else
        {
            StartCoroutine(AdvanceToNextCharacter());
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    private IEnumerator ResetQueue()
    {
        yield return null;
        owner.ChangeState<RoundStartState>();

    }

    private IEnumerator AdvanceToNextCharacter()
    {
        currentCharacter = owner.turnQueue.Dequeue();
        string msg = $"{currentCharacter.Name}'s turn";
        owner.UpdateInfoPanel(msg);

        yield return null;

        if (currentCharacter.faction == Faction.Hero)
        {
            owner.ChangeState<SelectActionState>();
        }
        else if (currentCharacter.faction == Faction.Enemy)
        {
            owner.ChangeState<EnemyTurnState>();
        }
        else
        {
            Debug.Log("Invalid character faction");
        }
    }
}
