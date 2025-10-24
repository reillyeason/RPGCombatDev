using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class RoundStartState : CombatState
{
    public override void Enter()
    {
        base.Enter();

        StartCoroutine(DetermineOrder());
    }

    public override void Exit()
    {
        base.Exit();
    }

    private IEnumerator DetermineOrder()
    {
        var turnQueue = new Queue<Character>();

        foreach (var battler in battlers)
        {
            turnQueue.Enqueue(battler);
        }

        owner.turnQueue = turnQueue;

        yield return null;
        owner.ChangeState<AdvanceTurnState>();
    }
}
