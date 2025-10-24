using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Linq;

public class CombatManager : StateMachine
{
    public MenuEventSystemHandler menuEventSystemHandler;
    public AbilityMenuEventSystemHandler skillMenuHandler;
    public TargetMenuEventSystemHandler targetMenuHandler;
    public List<CharStatPanelHandler> charStatPanelHandlers;

    [Header("Panels")]
    public GameObject combatPanel;
    public GameObject actionPanel;
    public GameObject skillPanel;
    public GameObject targetPanel;
    public GameObject infoPanel;
    public GameObject[] charStatPanels;
    //public GameObject buttonFactory;

    [Header("Characters")]
    //public Character player;
    //public Character enemy;
    public List<Character_SO> heroes_SO;
    public List<Character_SO> enemies_SO;
    public List<Character> heroes;
    public List<Character> enemies;
    public List<Character> battlers;
    public CombatCharacterFactory combatCharacterFactory;

    public EnemyAI enemyAI;

    //public List<Character> turnQueue;
    public Queue<Character> turnQueue;

    public Character currentCharacter;

    public ActionManager actionManager;


    void Start()
    {
        //charStatPanelHandler = charStatPanel.GetComponent<CharStatPanelHandler>();
        //charStatPanelHandler.character = heroes[0];

        enemyAI = new EnemyAI();
        actionManager = new ActionManager();
        heroes = new List<Character>();
        enemies = new List<Character>();
        battlers = new List<Character>();
        combatCharacterFactory = new CombatCharacterFactory();
        menuEventSystemHandler = combatPanel.GetComponent<MenuEventSystemHandler>();
        skillMenuHandler = skillPanel.GetComponent<AbilityMenuEventSystemHandler>();
        targetMenuHandler = targetPanel.GetComponent<TargetMenuEventSystemHandler>();
        ChangeState<InitCombatState>();
    }

    public void UpdateInfoPanel(string infoText)
    {
        infoPanel.GetComponentInChildren<TMP_Text>().text = infoText;
    }

    public void QueueAction(ActionBase action)
    {
        actionManager.QueueAction(action);
    }

    public void UnqueueAction()
    {
        actionManager.UnqueueAction();
    }

    public void RemoveBattler(Character character)
    {
        
        battlers.Remove(character);
        
        if (character.faction == Faction.Hero)
            heroes.Remove(character);
        else if (character.faction == Faction.Enemy)
            enemies.Remove(character);

        Queue<Character> newQueue = new Queue<Character>(turnQueue.Where(item => item != character));
        turnQueue = newQueue;

        StartCoroutine(DeathAnimCO(character));
    }

    private IEnumerator DeathAnimCO(Character character)
    {
        character.animator.SetTrigger("Death");
        yield return new WaitForSeconds(3);

        Destroy(character.gameObject);
    }

    public void AssignCharStatPanel(CharStatPanelHandler handler, Character character)
    {
        handler.character = character;
    }

}