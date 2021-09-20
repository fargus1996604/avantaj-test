using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;
    public SpriteRenderer Sprite => _sprite;

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

    public Vector3 TopMidPoint
    {
        get
        {
            if(Sprite != null)
            {
                return Sprite.transform.position;
            }
            return Vector3.zero;
        }
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

    private void Update()
    {
        Position += MoveSpeed * Time.deltaTime;
        Sprite.material.SetTextureOffset("_MainTex", new Vector2(0, Position));
    }
}
