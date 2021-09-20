using System.Collections.Generic;

[System.Serializable]
public class LevelData
{
    private ItemData _firstItem;
    public ItemData FirstItem
    {
        get => _firstItem;
        private set => _firstItem = value;
    }

    private ItemData _secondItem;
    public ItemData SecondItem
    {
        get => _secondItem;
        private set => _secondItem = value;
    }

    private int _maxPoints;
    public int MaxPoints
    {
        get => _maxPoints;
        private set => _maxPoints = value;
    }

    private int _points;
    public int Points
    {
        get => _points;
        set => _points = value;
    }

    public LevelData(ItemData fisrtItem, ItemData secondItem, int maxPoints)
    {
        FirstItem = fisrtItem;
        SecondItem = secondItem;
        MaxPoints = maxPoints;
    }

    public List<ItemData> ItemDataAsList => new List<ItemData> { FirstItem, SecondItem };
}
