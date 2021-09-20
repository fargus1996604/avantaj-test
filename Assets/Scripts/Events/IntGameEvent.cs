using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntGameEvent", menuName = "Event/IntGameEvent", order = 1)]
public class IntGameEvent : GameEvent
{
    private int _number;
    public int Number
    {

        get => _number;
        private set => _number = value;
    }

    public void Raise(int number)
    {
        Number = number;
        base.Raise();
    }
}
