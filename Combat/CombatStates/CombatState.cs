using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CombatState : State
{
    protected CombatManager owner;

    // DEVELOPMENT: These should be abstracted eventually
    //public Character player { get { return owner.player; } }
    //public Character enemy { get { return owner.enemy; } }
    public List<Character> enemies { get { return owner.enemies; } set { owner.enemies = value; } }
    public List<Character> heroes {  get { return owner.heroes; } set { owner.heroes = value; } }
    public List<Character> battlers { get { return owner.battlers; } set { owner.battlers = value; } }
    public Character currentCharacter { get { return owner.currentCharacter; } set { owner.currentCharacter = value; } }

    // WORKING
    public MenuEventSystemHandler menuEventSystemHandler { get { return owner.menuEventSystemHandler; } }
    public AbilityMenuEventSystemHandler skillMenuHandler { get { return owner.skillMenuHandler; } }
    public TargetMenuEventSystemHandler targetMenuHandler { get { return owner.targetMenuHandler; } }
    public GameObject combatPanel { get { return owner.combatPanel; } }
    public GameObject actionPanel { get { return owner.actionPanel; } }
    public GameObject skillPanel { get { return owner.skillPanel; } }
    public GameObject targetPanel { get { return owner.targetPanel; } }
    public GameObject infoPanel { get { return owner.infoPanel; } set { owner.infoPanel = value; } }
    public ActionManager actionManager {  get { return owner.actionManager; } }

    private void Awake()
    {
        owner = GetComponent<CombatManager>();
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        Death.DeathEvent += OnDeath;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        Death.DeathEvent -= OnDeath;
    }

    protected void OnDeath(Character character)
    {
        owner.RemoveBattler(character);
        StartCoroutine(DeathTrigger(character));
        //owner.ChangeState<CheckConditionsState>();
    }

    protected IEnumerator DeathTrigger(Character character)
    {
        owner.UpdateInfoPanel($"{character} defeated");
        yield return new WaitForSeconds(2);
        owner.ChangeState<CheckConditionsState>();
    }
}
