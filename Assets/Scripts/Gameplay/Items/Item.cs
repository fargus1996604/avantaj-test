using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _baseRenderer;
    public SpriteRenderer BaseRenderer => _baseRenderer;

    [SerializeField]
    private SpriteRenderer _highlightRenderer;
    public SpriteRenderer HighlightRendere => _highlightRenderer;

    [SerializeField]
    private ItemData _data;
    public ItemData Data
    {
        get => _data;
        private set => _data = value;
    }

    private bool _highlight;

    public void UpdateItem(ItemData data)
    {
        Data = data;
        UpdateView();
    }

    private void UpdateView()
    {
        if (BaseRenderer == null)
        {
            Debug.LogWarning("BaseRenderer is not assigned!!");
            return;
        }

        if (HighlightRendere == null)
        {
            Debug.LogWarning("HighlightRendere is not assigned!!");
            return;
        }

        if (Data == null)
        {
            Debug.LogWarning("Data is not assigned!!");
            return;
        }

        BaseRenderer.sprite = Data.BaseSprite;
        HighlightRendere.sprite = Data.HighlightSprite;
        HighlightRendere.gameObject.SetActive(_highlight);
    }

    public void HighlightOn()
    {
        _highlight = true;
        HighlightRendere.gameObject.SetActive(_highlight);
    }

    public void HighlightOff()
    {
        _highlight = false;
        HighlightRendere.gameObject.SetActive(_highlight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;

        if (collision.attachedRigidbody.TryGetComponent<ActionZone>(out var _))
        {
            HighlightOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;

        if (collision.attachedRigidbody.TryGetComponent<ActionZone>(out var _))
        {
            HighlightOff();
        }
    }
}
