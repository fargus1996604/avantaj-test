using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    private string _fileName;

    [SerializeField]
    private RankingData _data;

    private LevelData _levelData;

    private void Start()
    {
        LoadData();
    }

    public void OnGameEnd()
    {
        if (_levelData == null)
        {
            Debug.LogWarning("LevelData is null!!");
            return;
        }

        if (_data == null || _data.Top == null || _data.Top.Count == 0)
        {
            _data = new RankingData() { Top = new List<int>() { _levelData.Points } };
            SaveData();
            return;
        }

        _data.Top.Add(_levelData.Points);
        _data.Top = _data.Top.OrderByDescending(d => d).ToList();
        if (_data.Top.Count > 5)
        {
            int removeCount = _data.Top.Count - 5;
            _data.Top.RemoveRange(5, removeCount);
        }
        SaveData();
    }

    public void OnGameLevelLoaded(LevelGameEvent eventData)
    {
        _levelData = eventData.Data;
    }

    private void LoadData()
    {
        string content = new LocalStorageDataProvider(_fileName).ReadAllText();
        if (content != string.Empty)
        {
            var data = JsonUtility.FromJson<RankingData>(content);
            if (data != null)
            {
                _data = data;
            }
        }
        else
        {
            _data = new RankingData() { Top = new List<int>() };
        }
    }

    private void SaveData()
    {
        string content = JsonUtility.ToJson(_data);
        new LocalStorageDataProvider(_fileName).WriteAllText(content);
        Debug.Log($"Saved {GetFullPath()}");
    }

    private string GetFullPath()
    {
        return Path.Combine(Application.dataPath, _fileName);
    }
}
