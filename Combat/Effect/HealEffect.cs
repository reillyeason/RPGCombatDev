using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Effect", menuName = "Effects/Heal")]
public class HealEffect : EffectStrategy
{
    [SerializeField] int amount;
    public override void Apply(Character user, IEnumerable<Character> targets, int power)
    {
        foreach (var target in targets)
        {
            target.TakeDamage(-power); // negative value will increase health in TakeDamage
        }
    }
}
