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
    public float MoveSpeed => _moveSpeed * _moveRatio;

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
            if (Sprite != null)
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

    private float _moveRatio = 0f;

    private void Update()
    {
        Position += MoveSpeed * Time.deltaTime;
        Sprite.material.SetTextureOffset("_MainTex", new Vector2(0, Position));
    }

    public void TurnOn()
    {
        StopAllCoroutines();
        StartCoroutine(LerpMoveRatio(1f, 1f));
    }

    public void TurnOff()
    {
        StopAllCoroutines();
        StartCoroutine(LerpMoveRatio(0f, 1f));
    }

    private IEnumerator LerpMoveRatio(float endValue, float duration)
    {
        float startValue = _moveRatio;
        float time = 0;
        while (_moveRatio != endValue)
        {
            _moveRatio = Mathf.Lerp(startValue, endValue, time);
            time += Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }
    }
}
