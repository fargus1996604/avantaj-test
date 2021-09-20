using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ActionZone : MonoBehaviour
{
    private BoxCollider2D _collider;
    public BoxCollider2D Collider
    {
        get
        {
            if (_collider == null)
            {
                _collider = GetComponent<BoxCollider2D>();
            }
            return _collider;
        }
    }

    [SerializeField]
    private List<Item> _items = new List<Item>();
    public List<Item> Items => _items;

    public bool HasItems => _items.Count > 0;

    private void FixedUpdate()
    {
        _items.Clear();
        var results = Physics2D.BoxCastAll((Vector2)transform.position + Collider.offset, Collider.size, 0, transform.forward);

        foreach (var result in results) 
        {
            if(result.collider.TryGetComponent<Item>(out var item))
            {
                _items.Add(item);
            }
        }
    }
}
