using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FilterStrategy : ScriptableObject
{
    public abstract IEnumerable<Character> Filter(Character user, IEnumerable<Character> possibleTargets);
}
