using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableItemSpawner
{
    public ConveyorMove Spawn(GameObject obj, Vector3 position)
    {
        var item = new ItemSpawner().Spawn(obj, position);
        if(item != null)
        {
            return item.gameObject.AddComponent<ConveyorMove>();
        }

        return null;
    }
}
