using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;
    public SpriteRenderer Sprite => _sprite;

    [SerializeField]
    private Bounds _bounds;
    public Bounds Bounds => _bounds;

    [SerializeField]
    private float _partheight;
    public float PartHeight => _partheight;

    [SerializeField]
    private int _partsCount;
    public int PartsCount => _partsCount;

    [SerializeField]
    private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    [SerializeField]
    private float _position;
    public float Position
    {
        get => _position;
        private set => _position = value;
    }

    public Vector3 MoveDirection
    {
        get
        {
            if (Sprite != null)
            {
                return -Sprite.transform.up;
            }
            return Vector3.zero;
        }
    }

    private List<ConveyorMove> _items;

    private void Update()
    {
        Position += MoveSpeed * Time.deltaTime;
        Sprite.material.SetTextureOffset("_MainTex", new Vector2(0, Position));
    }

    public void PlaceItem(ConveyorMove item)
    {
        if (_items.Contains(item)) return;
        item.Controller = this;
        _items.Add(item);
    }

    public void DropItem(ConveyorMove item)
    {
        if (_items.Remove(item))
        {
            item.Controller = null;
        }
    }

    public bool IsItemOnPlatform(ConveyorMove item)
    {
        return GetPlatformBounds().Contains(item.transform.position);
    }

    public Bounds GetPlatformBounds()
    {
        return new Bounds(transform.position + Bounds.center, Bounds.size);
    }
}
