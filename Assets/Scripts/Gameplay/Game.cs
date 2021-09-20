using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private ItemList _itemsContainer;

    [SerializeField]
    private LevelGameEvent _levelWasLoaded;

    private LevelData _level;
    public LevelData Level
    {
        get => _level;
        private set => _level = value;
    }

    private void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        var itemsGroup = GetRandomItems(_itemsContainer.Items);
        if (itemsGroup.firstItem != null && itemsGroup.secondItem != null)
        {
            Level = new LevelData(itemsGroup.firstItem, itemsGroup.secondItem);
            _levelWasLoaded.Raise(Level);
        }
    }

    private (ItemData firstItem, ItemData secondItem) GetRandomItems(List<ItemData> items)
    {
        if (items.Count < 3) return (null, null);

        var random = new System.Random();
        var randomizedList = items.OrderBy(item => random.Next()).ToList();
        return (randomizedList[0], randomizedList[1]);
    }
}
