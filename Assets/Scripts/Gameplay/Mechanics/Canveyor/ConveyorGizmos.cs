using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyorController))]
public class ConveyorGizmos : MonoBehaviour
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Controller.Sprite.transform.position, 0.2f);

        Gizmos.color = Color.green;
        DrawArrowGizmos(Controller.TopMidPoint, Controller.MoveDirection);
    }

    private void DrawArrowGizmos(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Gizmos.DrawRay(pos, direction);
        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
        Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
    }
}
