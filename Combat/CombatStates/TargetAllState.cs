using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TargetAllState : SelectTargetState
{
    protected override void OnTargetClick(Character target)
    {
        Button[] buttons = panelController.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            ButtonContainer<Character> buttonContainer = button.GetComponent<ButtonContainer<Character>>();
            actionManager.SetTarget(buttonContainer.GetEntry());
        }
        owner.ChangeState<PerformActionState>();
        //target.TakeDamage((int)currentCharacter.attack.Value);
    }
}
