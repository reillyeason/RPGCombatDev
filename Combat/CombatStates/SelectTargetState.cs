using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class SelectTargetState : CombatState
{
    public event Action Targeted;
    protected PanelController panelController;

    public override void Enter()
    {
        base.Enter();

        panelController = targetPanel.GetComponent<PanelController>();

        List<Character> targets = GetTargets();
        panelController.CreateButtons<Character>(targets);
        targetPanel.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        panelController.DeleteButtons();
        targetPanel.SetActive(false);
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        targetMenuHandler.TargetEvent += OnTargetClick;
        targetMenuHandler.CancelButtonEvent += OnCancel;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        targetMenuHandler.TargetEvent -= OnTargetClick;
        targetMenuHandler.CancelButtonEvent -= OnCancel;
    }

    protected virtual void OnTargeted(Character target)
    {
        Targeted?.Invoke();
    }

    protected virtual void OnTargetClick(Character target)
    {
        // TODO: This will likely only work for single target
        // NEED TO FIGURE OUT HOW TO MAKE MULTI TARGET
    //    clickCount++;
    //    Targeted?.Invoke();
    //    actionManager.SetTarget(target);
    //    int numButtons = panelController.GetComponentsInChildren<Button>().Length;
    //    Debug.Log($"Number of buttons is : {numButtons}");
    //    if (clickCount >= numButtons)
    //    {
    //        owner.ChangeState<PerformActionState>();
    //    }
        //target.TakeDamage((int)currentCharacter.attack.Value);
    }

    private void OnCancel()
    {
        //panelController.DeleteButtons();
        actionManager.UnqueueAction();
        owner.ChangeState<SelectActionState>();
    }

    private List<Character> GetTargets()
    {
        List<Character> _targets = new List<Character>();
        //_targets = currentCharacter.abilityRunner.Filter(currentCharacter, battlers);
        //_targets = currentCharacter.FilterTargets(battlers);
        _targets = actionManager.Filter(currentCharacter, battlers);
        return _targets;
    }
}
