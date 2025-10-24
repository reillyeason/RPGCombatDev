using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityMenuEventSystemHandler : DynamicMenuEventSystemHandler
{
    public event Action<Ability> AbilityEvent;

    public override void OnPressed(BaseEventData eventData)
    {
        AbilityButton buttonContainer = eventData.selectedObject.GetComponentInChildren<AbilityButton>();
        AbilityEvent?.Invoke(buttonContainer.GetEntry());

    }
}
