using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitCombatState : CombatState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    public IEnumerator Init()
    {
        // dev stuff refactor this later
        //currentCharacter = player;
        // do some stuff
        // determine who acts first
        heroes = owner.combatCharacterFactory.CreateCharacters(owner.heroes_SO);
        enemies = owner.combatCharacterFactory.CreateCharacters(owner.enemies_SO);

        InitStatPanels();

        battlers = new List<Character>();
        SetBattlers();

        yield return null;
        owner.ChangeState<RoundStartState>();
    }

    private void SetBattlers()
    {
        foreach (Character character in heroes)
        {
            battlers.Add(character);
        }
        foreach (Character character in enemies)
        {
            battlers.Add(character);
        }
    }

    private void InitStatPanels()
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            CharStatPanelHandler handler = owner.charStatPanels[i].GetComponent<CharStatPanelHandler>();
            owner.charStatPanelHandlers.Add(handler);
            owner.AssignCharStatPanel(owner.charStatPanelHandlers[i], heroes[i]);
            owner.charStatPanels[i].SetActive(true);
        }
    }
}
