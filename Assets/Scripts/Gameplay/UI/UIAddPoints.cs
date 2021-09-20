using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class UIAddPoints : MonoBehaviour
{
    private Canvas _canvas;
    public Canvas Canvas
    {
        get
        {
            if(_canvas == null)
            {
                _canvas = GetComponent<Canvas>();
            }
            return _canvas;
        }
    }

    [SerializeField]
    private Text _pointsText;

    private void Start()
    {
        Canvas.worldCamera = Camera.main;
    }

    public void ShowPoints(int points)
    {
        if (_pointsText == null)
        {
            Debug.LogWarning("_pointsText is not assigned!!");
            return;
        }

        _pointsText.text = $"+{points}";
    }
}
