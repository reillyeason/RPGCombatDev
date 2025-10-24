using UnityEngine;

public class GameState : State
{
    protected GameManager owner;
    private void Awake()
    {
        owner = GetComponent<GameManager>();
    }
}

