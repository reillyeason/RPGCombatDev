using UnityEngine;

public class BattleLostState : CombatState
{
    public override void Enter()
    {
        base.Enter();

        owner.UpdateInfoPanel("You died, git gud");
    }
}
