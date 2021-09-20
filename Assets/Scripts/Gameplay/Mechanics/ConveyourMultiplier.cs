using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Game))]
public class ConveyourMultiplier : MonoBehaviour
{
    private Game _game;
    public Game Game
    {
        get
        {
            if (_game == null)
            {
                _game = GetComponent<Game>();
            }
            return _game;
        }
    }

    [SerializeField]
    private ConveyorController _controller;

    private int _collectedCount = 0;

    public void OnItemCollected()
    {
        _collectedCount++;
        if (_collectedCount % Game.Configuration.ConveyorMultiplyAfter == 0)
        {
            _controller.MoveSpeed *= Game.Configuration.ConveyorMultiplier;
        }
    }

    public void OnGameLevelLoaded()
    {
        _collectedCount = 0;
        _controller.MoveSpeed = Game.Configuration.ConveyorSpeed;
    }
}
