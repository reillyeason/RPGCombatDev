using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyAI
{
    private Character character;

    public Ability ChooseRandomAbility(Character enemy)
    {
        int numAbilities = enemy.abilities.Length;
        int randomIndex = Random.Range(0, numAbilities);

        return enemy.abilities[randomIndex];
    }

    public Character SelectRandomTarget(List<Character> targets)
    {
        int numTargets = targets.Count;
        int randomIndex = Random.Range(0, numTargets);

        return targets[randomIndex];
    }
}
