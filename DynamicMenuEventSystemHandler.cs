using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DynamicMenuEventSystemHandler : MenuEventSystemHandler
{
    private Selectable[] panelSelectables;

    public override void Awake()
    {
        //override base Awake and do nothing
        //logic to AddListeners is moved to OnEnable
    }
    public override void OnEnable()
    {
        // find all Buttons in panel and add them to Selectables
        panelSelectables = GetComponentsInChildren<Selectable>();

        foreach (var selectable in panelSelectables)
        {
            Selectables.Add(selectable);
        }
        _firstSelected = Selectables[0];

        foreach (var selectable in Selectables)
        {
            AddSelectionListeners(selectable);
            _positions.Add(selectable, selectable.GetComponent<RectTransform>().localPosition);
        }
        base.OnEnable();
    }

    public override void OnSelect(BaseEventData eventData)
    {

    }

    public override void OnDeselect(BaseEventData eventData)
    {

    }



    public override void OnDisable()
    {
        base.OnDisable();
        // Make sure to clear the array for next time it is loaded
        Selectables.Clear();

        //Button[] buttons = GetComponentsInChildren<Button>();
        //foreach (Button button in buttons)
        //{
        //    Destroy(button.gameObject);
        //}
    }
}
