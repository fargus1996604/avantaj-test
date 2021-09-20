using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameEvent _gameLose;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Item>(out var item))
        {
            if (item.TryGetComponent<ConveyorMove>(out var move))
            {
                Destroy(move);
            }

            item.transform.DOMoveY(-10, 4f).OnComplete(() => { Destroy(item.gameObject); });
            _gameLose?.Raise();
        }
    }
}
