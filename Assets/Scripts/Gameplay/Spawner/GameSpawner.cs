using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Game))]
public class GameSpawner : MonoBehaviour
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
    private ConveyorController _conveyorController;

    [SerializeField]
    private int _spawnStep = 1;

    [SerializeField]
    private GameObject _itemObject;

    [SerializeField]
    [Range(1,10)]
    private int _maxSameItemCount;

    private float _lastSpawnerPosition;

    private KeyValuePair<ItemData, int> _lastItemSpawnedData = new KeyValuePair<ItemData, int>();

    private void Update()
    {
        if (Game.Level == null) return;

        if (_lastSpawnerPosition + (_spawnStep + 0.5f) <= _conveyorController.Position)
        {
            var randomItemData = GetRandomItem(Game.Level.ItemDataAsList);
            new MovableItemSpawner().Spawn(_itemObject, _conveyorController.TopMidPoint, randomItemData);
            _lastSpawnerPosition = Mathf.CeilToInt(_conveyorController.Position);

            int spawndCount = _lastItemSpawnedData.Key == randomItemData ? _lastItemSpawnedData.Value + 1 : 1;
            _lastItemSpawnedData = new KeyValuePair<ItemData, int>(randomItemData, spawndCount);
        }
    }

    private ItemData GetRandomItem(List<ItemData> items)
    {
        var random = new System.Random();
        var randomizedList = items.OrderBy(item => random.Next()).ToList();
        if (_lastItemSpawnedData.Key == randomizedList.First() && _lastItemSpawnedData.Value >= _maxSameItemCount)
        {
            return randomizedList.Last();
        }
        return randomizedList.First();
    }
}
