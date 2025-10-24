using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities", fileName = "Default Ability")]
public class Ability : ActionBase, IHasName
{
    
    [SerializeField] TargetingStrategy targetingStrategy;
    [SerializeField] FilterStrategy filterStrategy;
    [SerializeField] EffectStrategy effectStrategy;

    //public Character target;
    public int abilityPower;
    public int cost;
    public override void Use(Character user, IEnumerable<Character> targets)
    {
        user.ap.CurrentValue -= cost;
        effectStrategy.Apply(user, targets, abilityPower);
    }

    public override IEnumerable<Character> Filter(Character user, IEnumerable<Character> targets)
    {
        targets = filterStrategy.Filter(user, targets);
        foreach (Character target in targets)
        {
            yield return target;
        }
    }
}
