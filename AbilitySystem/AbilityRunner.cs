using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRunner
{
    private Ability currentAbility;
    public void Use(Character user, Ability ability, IEnumerable<Character> targets)
    {
        ability.Use(user, targets);
    }

    public List<Character> Filter(Character user, IEnumerable<Character> targets)
    {
        targets = currentAbility.Filter(user, targets);
        return targets.ToList();
    }

    public void QueueAbility(Ability ability)
    {
        currentAbility = ability;
    }
}
