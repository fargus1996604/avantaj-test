using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Data/ItemList", order = 1)]
public class ItemList : ScriptableObject
{
    public List<ItemData> Items;
}

[System.Serializable]
public class ItemData
{
    [SerializeField]
    private Sprite _baseSprite;
    public Sprite BaseSprite => _baseSprite;

    [SerializeField]
    private Sprite _highlightSprite;
    public Sprite HighlightSprite => _highlightSprite;

    [SerializeField]
    private Sprite _shadowSprite;
    public Sprite ShadowSprite => _shadowSprite;
}