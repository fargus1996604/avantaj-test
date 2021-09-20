using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMove : MonoBehaviour
{
    [SerializeField]
    private ConveyorController _controller;
    public ConveyorController Controller
    {
        get => _controller;
        set => _controller = value;
    }

    private void Update()
    {
        if (Controller == null || Controller.IsItemOnPlatform(this) == false) return;
        transform.position += Controller.MoveDirection * (Controller.MoveSpeed * Controller.PartHeight) * Time.deltaTime;
    }
}
