using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectSkillState : CombatState
{
    PanelController panelController;
    public override void Enter()
    {
        base.Enter();

        List<Ability> panelAbilities = new List<Ability>();
        foreach (var ability in currentCharacter.abilities)
        {
            panelAbilities.Add(ability);
        }

        panelController = skillPanel.GetComponent<PanelController>();
        panelController.CreateButtons<Ability>(panelAbilities);
        skillPanel.SetActive(true);
        
    }

    public override void Exit()
    {
        base.Exit();
        panelController.DeleteButtons();
        skillPanel.SetActive(false);
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        skillMenuHandler.AbilityEvent += OnAbilityClick;
        skillMenuHandler.CancelButtonEvent += OnCancel;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        skillMenuHandler.AbilityEvent -= OnAbilityClick;
        skillMenuHandler.CancelButtonEvent -= OnCancel;
    }

    private void OnAbilityClick(Ability ability)
    {
        //currentCharacter.QueueAbility(ability);
        //owner.QueueAction(ability);
        if (currentCharacter.ap.CurrentValue < ability.cost)
        {
            Debug.Log($"Not enough ap {currentCharacter.ap.CurrentValue}");
            // infoPanel
            return;
        }
        actionManager.QueueAction(ability);
        if (actionManager.GetTargetingType() == TargetingType.Single)
        {
            owner.ChangeState<SelectSingleTargetState>();
        }
        else if (actionManager.GetTargetingType() == TargetingType.All)
        {
            owner.ChangeState<TargetAllState>();
        }
        else
        {
            Debug.Log("No valid targeting type");
        }
    }

    private void OnCancel()
    {
        owner.ChangeState<SelectActionState>();
    }
}
