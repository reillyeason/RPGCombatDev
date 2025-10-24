using UnityEngine;
using System.Collections.Generic;

public abstract class EffectStrategy : ScriptableObject
{
    public abstract void Apply(Character user, IEnumerable<Character> targets, int power);
}
