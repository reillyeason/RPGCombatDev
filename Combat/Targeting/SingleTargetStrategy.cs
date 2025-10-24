using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Single Target Strategy", menuName = "Targeting/SingleTarget")]
public class SingleTargetStrategy : TargetingStrategy
{
    public override void Target(Character user, Action<IEnumerable<Character>> finished)
    {
        Debug.Log("Setting target");
        finished(null);
    }

    private IEnumerable<Character> GetPossibleTargets(List<Character> targets)
    {
        foreach (Character target in targets)
        {
            yield return target;
        }
    }
}
