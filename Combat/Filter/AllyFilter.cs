using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Ally Filter Strategy", menuName = "FilterStrategies/Team")]
public class AllyFilter : FilterStrategy
{
    public override IEnumerable<Character> Filter(Character user, IEnumerable<Character> possibleTargets)
    {
        foreach (Character target in possibleTargets)
        {
            if (target.faction == user.faction)
                yield return target;
        }
    }
}
