using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner
{
    public Item Spawn(GameObject obj, Vector3 position)
    {
        var itemObject = Object.Instantiate(obj, position, Quaternion.identity);
        if (itemObject.TryGetComponent<Item>(out var item))
        {
            return item;
        }
        return null;
    }
}
