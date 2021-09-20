using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ConveyorMove : MonoBehaviour
{
    private BoxCollider2D _collider;
    public BoxCollider2D Collider
    {
        get
        {
            if(_collider == null)
            {
                _collider = GetComponent<BoxCollider2D>();
            }
            return _collider;
        }
    }

    [SerializeField]
    private ConveyorController _controller;
    public ConveyorController Controller
    {
        get => _controller;
        set => _controller = value;
    }

    private void Start()
    {
        Collider.isTrigger = true;
    }

    private void Update()
    {
        if (Controller == null) return;
        transform.position += Controller.MoveDirection * (Controller.MoveSpeed * Controller.PartHeight) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ConveyorController>(out var controller))
        {
            Controller = controller;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ConveyorController>(out var controller))
        {
            if(Controller == controller)
            {
                Controller = null;
            }
        }
    }
}
