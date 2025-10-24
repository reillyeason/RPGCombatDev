using UnityEngine;

[CreateAssetMenu(fileName = "BaseStats", menuName = "Stats/BaseStats")]
public class BaseStats : ScriptableObject
{
    public string Name;
    public Resource health;
    public Resource ap;
    public int attack;
    public int defense;
    public int speed;
    public Faction faction;
}
