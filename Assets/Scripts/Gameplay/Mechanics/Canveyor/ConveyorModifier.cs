using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
[RequireComponent(typeof(ConveyorController))]
public class ConveyorModifier : MonoBehaviour
{
    private ConveyorController _controller;
    public ConveyorController Controller
    {
        get
        {
            if (_controller == null)
            {
                _controller = GetComponent<ConveyorController>();
            }
            return _controller;
        }
    }

    private void Update()
    {
        if (Application.isPlaying) return;
        Controller.Sprite.size = new Vector2(Controller.Sprite.size.x, Controller.PartHeight * Controller.PartsCount);
    }
}
