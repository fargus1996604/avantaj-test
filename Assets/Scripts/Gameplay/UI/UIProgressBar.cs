using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image _filledImage;

    [SerializeField]
    private Text _pointText;

    [SerializeField]
    private LevelData _data;

    public void SetLevelData(LevelGameEvent eventData)
    {
        _data = eventData.Data;
        UpdateView();
    }

    public void UpdateView()
    {
        if(_filledImage == null)
        {
            Debug.LogWarning("_filledImage is not assigned!!");
            return;
        }

        if (_pointText == null)
        {
            Debug.LogWarning("_pointText is not assigned!!");
            return;
        }

        if (_data == null)
        {
            Debug.LogWarning("LevelData is not assigned!!");
            return;
        }

        _filledImage.fillAmount = _data.Points / _data.MaxPoints;
        _pointText.text = _data.Points.ToString();
    }
}
