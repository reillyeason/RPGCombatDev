using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.InputSystem;
using System.Collections;
using System;

public class MenuEventSystemHandler : MonoBehaviour
{
    //public event Action<string> ActionButtonPressedEvent;
    public event Action<Ability> AttackButtonEvent;
    public event Action SkillButtonEvent;
    public event Action CancelButtonEvent;

    [Header("References")]
    public List<Selectable> Selectables = new List<Selectable>();
    [SerializeField] protected Selectable _firstSelected;

    [Header("Controls")]
    [SerializeField] protected InputActionReference _navigateReference;

    [Header("Animations")]
    [SerializeField] protected float _selectedAnimationScale = 1.1f;
    [SerializeField] protected float _scaleDuration = 0.25f;

    protected Dictionary<Selectable, Vector3> _positions = new Dictionary<Selectable, Vector3>();

    protected Selectable _lastSelected;

    protected Tween _moveRightTween;
    protected Tween _moveLeftTween;

    public virtual void Awake()
    {
        foreach (var selectable in Selectables)
        {
            AddSelectionListeners(selectable);
            _positions.Add(selectable, selectable.GetComponent<RectTransform>().localPosition);
        }
    }


    public virtual void OnEnable()
    {
        _navigateReference.action.performed += OnNavigate;

        for (int i = 0; i < Selectables.Count; i++)
        {
            Selectables[i].GetComponent<RectTransform>().localPosition = _positions[Selectables[i]];
        }
        
        StartCoroutine(SelectAfterDelay());
    }
    protected virtual IEnumerator SelectAfterDelay()
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(_firstSelected.gameObject);
    }

    public virtual void OnDisable()
    {
        _navigateReference.action.performed -= OnNavigate;
        _moveLeftTween.Kill(true);
        _moveRightTween.Kill(true);
    }

    protected virtual void AddSelectionListeners(Selectable selectable)
    {
        EventTrigger trigger = selectable.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = selectable.gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry SelectEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.Select
        };
        SelectEntry.callback.AddListener(OnSelect);
        trigger.triggers.Add(SelectEntry);

        EventTrigger.Entry DeselectEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.Deselect
        };
        DeselectEntry.callback.AddListener(OnDeselect);
        trigger.triggers.Add(DeselectEntry);

        EventTrigger.Entry PointerEnter = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        PointerEnter.callback.AddListener(OnPointerEnter);
        trigger.triggers.Add(PointerEnter);

        EventTrigger.Entry PointerExit = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerExit
        };
        PointerExit.callback.AddListener(OnPointerExit);
        trigger.triggers.Add(PointerExit);

        EventTrigger.Entry PointerClick = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick
        };
        PointerClick.callback.AddListener(OnPressed);
        trigger.triggers.Add(PointerClick);

        EventTrigger.Entry PressedEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.Submit
        };
        PressedEntry.callback.AddListener(OnPressed);
        trigger.triggers.Add(PressedEntry);

        EventTrigger.Entry CancelEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.Cancel
        };
        CancelEntry.callback.AddListener(OnCancel);
        trigger.triggers.Add(CancelEntry);
    }

    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("Cancel event triggered");
        CancelButtonEvent?.Invoke();
    }

    public virtual void OnPressed(BaseEventData eventData)
    {
        string buttonName = eventData.selectedObject.name;
        if (buttonName == "AttackButton")
        {
            AbilityButton buttonContainer = eventData.selectedObject.GetComponentInChildren<AbilityButton>();
            AttackButtonEvent?.Invoke(buttonContainer.GetEntry());
        }
        if (buttonName == "SkillsButton")
        {
            SkillButtonEvent?.Invoke();
        }
    }

    public virtual void OnSelect(BaseEventData eventData)
    {
        _lastSelected = eventData.selectedObject.GetComponent<Selectable>();

        float xMoveAmount = eventData.selectedObject.GetComponent<RectTransform>().localPosition.x + _selectedAnimationScale;
        _moveRightTween = eventData.selectedObject.GetComponent<RectTransform>().DOLocalMoveX(xMoveAmount, _scaleDuration);
    }

    public virtual void OnDeselect(BaseEventData eventData)
    {
        Selectable sel = eventData.selectedObject.GetComponent<Selectable>();
        _moveLeftTween = eventData.selectedObject.GetComponent<RectTransform>().DOLocalMoveX(_positions[sel].x, _scaleDuration);
    }

    public void OnPointerEnter(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        if (pointerEventData != null)
        {
            Selectable sel = pointerEventData.pointerEnter.GetComponentInParent<Selectable>();
            if (sel == null)
            {
                sel = pointerEventData.pointerEnter.GetComponentInChildren<Selectable>();
            }

            pointerEventData.selectedObject = sel.gameObject;
        }
    }

    public void OnPointerExit(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        if (pointerEventData != null)
        {
            pointerEventData.selectedObject = null;
        }
    }

    protected virtual void OnNavigate(InputAction.CallbackContext context)
    {
        if (EventSystem.current.currentSelectedGameObject == null && _lastSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(_lastSelected.gameObject);
        }
    }
}
