using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetMenuEventSystemHandler : DynamicMenuEventSystemHandler
{
    public event Action<Character> TargetEvent;

    public override void OnPressed(BaseEventData eventData)
    {
        TargetButton buttonContainer = eventData.selectedObject.GetComponentInChildren<TargetButton>();
        TargetEvent?.Invoke(buttonContainer.GetEntry());
    }
}
