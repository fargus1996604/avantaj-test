using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBox : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _renderer;
    public SpriteRenderer Renderer => _renderer;

    [SerializeField]
    private IntGameEvent _itemCollected;

    [SerializeField]
    private GameEvent _wrongItemCollected;

    [SerializeField]
    private GameObject _addPoints;

    [SerializeField]
    private Transform _addPointsSpawn;

    private ItemData _data;
    public ItemData Data
    {
        get => _data;
        private set => _data = value;
    }

    public void Setup(ItemData data)
    {
        Data = data;
        UpdateView();
    }

    private void UpdateView()
    {
        if (Renderer == null)
        {
            Debug.LogWarning("Renderer is not assigned!!");
            return;
        }

        if (Data == null)
        {
            Debug.LogWarning("Data is not assigned!!");
            return;
        }

        Renderer.sprite = Data.ShadowSprite;
    }

    public void CollectItem(Item item)
    {
        if (item.TryGetComponent<ConveyorMove>(out var move))
        {
            Destroy(move);
        }

        //Destroy item component to prevent trigger with other triggers
        Destroy(move);

        item.transform.DOMove(transform.position, 0.4f).OnComplete(() =>
        {
            if (item.Data == Data)
            {
                Destroy(item.gameObject);
                ShowAddPoints(10);
                _itemCollected.Raise(10);
            }
            else
            {
                item.transform.DOMoveY(-10, 4f).OnComplete(() => { Destroy(item.gameObject); });
                _wrongItemCollected.Raise();
            }
        });
    }

    private void ShowAddPoints(int points)
    {
        var addPoints = Instantiate(_addPoints, _addPointsSpawn.position, Quaternion.identity);
        if (addPoints.TryGetComponent<UIAddPoints>(out var uiAddPoints))
        {
            uiAddPoints.ShowPoints(points);
            uiAddPoints.transform.DOMoveY(1f, 1f).OnComplete(() => { Destroy(addPoints); });
        }
    }
}
