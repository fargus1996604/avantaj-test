using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelGameEvent", menuName = "Event/LevelGameEvent", order = 1)]
public class LevelGameEvent : GameEvent
{
    [SerializeField]
    private LevelData _data;
    public LevelData Data
    {
        get => _data;
        private set => _data = value;
    }

    public void Raise(LevelData data)
    {
        Data = data;
        base.Raise();
    }
}
