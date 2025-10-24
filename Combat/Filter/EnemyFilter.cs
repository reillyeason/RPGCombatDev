using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName  = "Enemy Filter Strategy", menuName = "FilterStrategies/Enemy")]
public class EnemyFilter : FilterStrategy
{
    public override IEnumerable<Character> Filter(Character user, IEnumerable<Character> possibleTargets)
    {
        foreach (Character target in possibleTargets)
        {
            if (target.faction != user.faction)
                yield return target;
        }
    }
}
