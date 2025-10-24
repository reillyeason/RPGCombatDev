using NUnit.Framework;
using System.Buffers;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Character : MonoBehaviour, IDamageable, IHasName
{
    [SerializeField] 
    private new string name;
    public string Name { get => name; set => name = value; }
    [SerializeField] private BaseStats statsSO;
    [SerializeField] public Resource health;
    [SerializeField] public Resource ap;
    [SerializeField] public CharacterStat attack;
    [SerializeField] public CharacterStat defense;
    [SerializeField] public CharacterStat speed;
    [SerializeField] public Faction faction;

    [SerializeField] public Ability[] abilities;

    public GameObject battlePrefab;
    public Animator animator;
    public HealthPresenter healthPresenter;

    private void Awake()
    {
        //SetBaseStats();
    }

    public void SetBaseStats(BaseStats statsSO)
    {
        Name = statsSO.Name;
        health = new Resource(statsSO.health);
        ap = new Resource(statsSO.ap); //initialize ap to 1 at start of battle
        attack = new CharacterStat(statsSO.attack);
        defense = new CharacterStat(statsSO.defense);
        speed = new CharacterStat(statsSO.speed);
        faction = statsSO.faction;
    }

    public void SetAbilities(Ability[] abilities)
    {
        this.abilities = abilities;
    }

    public void TakeDamage(int damage)
    {
        //currentHealth.BaseValue -= damage;
        //if (currentHealth.Value <= 0)
        //{

            // handle death
        //}
    }

    public void Heal(int amount)
    {
        //currentHealth.BaseValue += amount;
        //currentHealth.BaseValue = Mathf.Clamp(currentHealth.BaseValue, 0f, maxHealth.BaseValue);
    }
}
