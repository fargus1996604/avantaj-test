using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSortingController : MonoBehaviour
{
    [SerializeField]
    private CollectingBox _leftBox;

    [SerializeField]
    private CollectingBox _rightBox;

    [SerializeField]
    private ActionZone _actionZone;

    [SerializeField]
    private float _swipeDetectionDistance = 20f;

    private Vector2 _beginMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _beginMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Vector2.Distance(_beginMousePosition, Input.mousePosition) < _swipeDetectionDistance)
            {
                if (_actionZone.HasItems)
                {
                    if (Input.mousePosition.x < Screen.width / 2f)
                    {
                        _leftBox.CollectItem(_actionZone.Items.First());
                    }
                    else
                    {
                        _rightBox.CollectItem(_actionZone.Items.First());
                    }
                }
            }
            else
            {
                if (_actionZone.HasItems)
                {
                    if (IsRightSwipe(_beginMousePosition, Input.mousePosition))
                    {
                        _rightBox.CollectItem(_actionZone.Items.First());
                    }
                    else
                    {
                        _leftBox.CollectItem(_actionZone.Items.First());
                    }
                }
            }
        }
    }

    private bool IsRightSwipe(Vector2 beginPosition, Vector2 currentPosition)
    {
        return Vector2.Dot(Vector2.left, (beginPosition - currentPosition).normalized) > 0;
    }
}
