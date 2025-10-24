using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase : ScriptableObject, IHasName
{
    [SerializeField]
    private new string name;
    public string Name { get => name; set => name = value; }
    public TargetingType targetingType;
    public string animationTrigger;
    public abstract void Use(Character user, IEnumerable<Character> targets);

    public abstract IEnumerable<Character> Filter(Character user, IEnumerable<Character> targets);
}
