using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private ConveyorController _conveyorController;

    [SerializeField]
    private int _spawnStep = 1;

    [SerializeField]
    private GameObject _itemObject;

    [SerializeField]
    private float _lastSpawnerPosition;

    private void Update()
    {
        if (_lastSpawnerPosition + (_spawnStep + 0.5f) <= _conveyorController.Position)
        {
            new MovableItemSpawner().Spawn(_itemObject, _conveyorController.TopMidPoint);
            _lastSpawnerPosition = Mathf.CeilToInt(_conveyorController.Position);
        }
    }
}
