using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    private CollectingBox _leftBox;
    public CollectingBox LeftBox => _leftBox;

    [SerializeField]
    private CollectingBox _rightBox;
    public CollectingBox RightBox => _rightBox;

    public void Build(LevelGameEvent eventData)
    {
        var data = eventData.Data;
        if (data == null || data.FirstItem == null || data.SecondItem == null) return;
        LeftBox.Setup(data.FirstItem);
        RightBox.Setup(data.SecondItem);
    }
}
