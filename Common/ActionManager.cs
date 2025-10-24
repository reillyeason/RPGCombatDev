using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Collections;

public enum TargetingType { Single, All, None }

public class ActionManager
{
    // public for dev, set to private when finished
    public ActionBase currentAction = null;
    public List<Character> _targets = new List<Character>();
    public TargetingType targetingType = TargetingType.None;

    public void Use(Character user)
    {
        currentAction.Use(user, _targets);
    }

    public List<Character> Filter(Character user, IEnumerable<Character> targets)
    {
        targets = currentAction.Filter(user, targets);
        return targets.ToList();
    }

    public string GetActionAnimationTrigger()
    {
        return currentAction.animationTrigger;
    }

    public void SetTarget(Character target)
    {
        _targets.Add(target);
    }

    public void QueueAction(ActionBase action)
    {
        currentAction = action;
        targetingType = action.targetingType;
    }

    public void UnqueueAction()
    {
        currentAction = null;
    }

    public void Clear()
    {
        currentAction = null;
        _targets.Clear();
    }

    public TargetingType GetTargetingType()
    {
        return targetingType;
    }
}
