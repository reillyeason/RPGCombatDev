using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Effect", menuName = "Effects/Damage")]
public class DamageEffect : EffectStrategy
{
    [SerializeField] int damage;
    private DamageCalculator damageCalculator = new DamageCalculator();
    public override void Apply(Character user, IEnumerable<Character> targets, int abilityPower)
    {
        foreach (var target in targets)
        {
            int damage = damageCalculator.CalculateDamage(user, target, abilityPower);
            target.health.Decrement(damage);

            if (target.health.CurrentValue <= 0)
            {
                Death.DeathOccur(target);
            }
        }
    }
}
