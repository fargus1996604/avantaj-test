using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfiguration", menuName = "Data/GameConfiguration", order = 1)]
public class GameConfiguration : ScriptableObject
{
    [SerializeField]
    private int _maxPoints = 250;
    public int MaxPoints => _maxPoints;

    [SerializeField]
    private float _conveyourSpeed = 0.5f;
    public float ConveyorSpeed => _conveyourSpeed;

    [SerializeField]
    private float _conveyourMultiplier = 1.2f;
    public float ConveyorMultiplier => _conveyourMultiplier;

    [SerializeField]
    private int _conveyourMultiplyAfter = 5;
    public int ConveyorMultiplyAfter => _conveyourMultiplyAfter;
}
