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

    public LevelData(ItemData fisrtItem, ItemData secondItem)
    {
        FirstItem = fisrtItem;
        SecondItem = secondItem;
    }

    public List<ItemData> ItemDataAsList => new List<ItemData> { FirstItem, SecondItem };
}
