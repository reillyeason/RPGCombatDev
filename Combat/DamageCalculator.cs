using UnityEngine;

public class DamageCalculator
{
    public int CalculateDamage(Character attacker, Character defender, int abilityPower)
    {
        float _totalDamage = 0;
        float totalAttackDamage = CalculateAttack(attacker,abilityPower);
        float totalDefense =  CalculateDefense(defender);

        // Percentage calculation
        _totalDamage = totalAttackDamage * (100 / (100 + totalDefense));

        // Subtraction calculation
        //_totalDamage = totalAttackDamage - totalDefense;
        return (int)_totalDamage;
    }

    private float CalculateAttack(Character attacker, int abilityPower)
    {
        float attack = attacker.attack.Value * abilityPower;
        return attack;
    }

    private float CalculateDefense(Character defender)
    {
        float defense = defender.defense.Value;
        return defense;
    }
}
