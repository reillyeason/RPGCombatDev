using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacterFactory
{
    public Character CreateCharacter(Character_SO c_so)
    {
        GameObject prefab = c_so.battlePrefab;
        GameObject character_GO = GameObject.Instantiate(prefab);
        //character_GO.AddComponent<>

        character_GO.AddComponent<Character>();
        Character character = character_GO.GetComponent<Character>();
        character.SetBaseStats(c_so.stats);
        character.SetAbilities(c_so.abilities);
        character.animator = character_GO.GetComponent<Animator>();
        //character.SetBattlePrefab(c_so.battlePrefab);


        return character;
    }

    public List<Character> CreateCharacters(List<Character_SO> cso)
    {
        List<Character> characters = new List<Character>();
        foreach (var so in cso)
        {
            Character character = CreateCharacter(so);
            characters.Add(character);
        }
        return characters;
    }
}
