using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActionState : CombatState
{
    private Character target;
    private Button button;
    public override void Enter()
    {
        base.Enter();
        combatPanel.SetActive(true); 
    }

    public override void Exit()
    {
        base.Exit();
        combatPanel.SetActive(false);
    }

    protected override void AddListeners()
    {
        base.AddListeners();

        //menuEventSystemHandler.ActionButtonPressedEvent += OnActionClick;
        menuEventSystemHandler.AttackButtonEvent += OnAttackClick;
        menuEventSystemHandler.SkillButtonEvent += OnSkillClick;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        menuEventSystemHandler.AttackButtonEvent -= OnAttackClick;
        menuEventSystemHandler.SkillButtonEvent -= OnSkillClick;
    }

    public void OnAttackClick(Ability attackAbility)
    {
        Debug.Log("Attack button clicked message received");
        //currentCharacter.SetTarget(enemy);
        //target = currentCharacter.GetTarget();
        //target.TakeDamage((int)currentCharacter.attack.Value);
        owner.QueueAction(attackAbility);
        owner.ChangeState<SelectSingleTargetState>();
    }

    public void OnSkillClick()
    {
        owner.ChangeState<SelectSkillState>();
    }
}
