using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class TargetingStrategy : ScriptableObject
{
    public abstract void Target(Character user, Action<IEnumerable<Character>> finished);
}
