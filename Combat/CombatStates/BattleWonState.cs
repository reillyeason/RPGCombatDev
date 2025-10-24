using UnityEngine;

public class BattleWonState : CombatState
{
    public override void Enter()
    {
        base.Enter();

        owner.UpdateInfoPanel("You win baby!");
    }
}
