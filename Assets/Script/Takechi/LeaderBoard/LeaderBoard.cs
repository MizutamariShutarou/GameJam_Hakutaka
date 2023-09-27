using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] InputField _inputField;
    public RankData _rankData { get; set; } = new RankData();
    void Awake()
    {
        string json = PlayerPrefs.GetString("LeaderBoard");
        if(json != string.Empty) _rankData = JsonUtility.FromJson<RankData>(json);
    }
    public void PlayerEntry()
    {
        Player player;
        player.Name = _inputField.text;
        player.MovingDistance = TrainManager._movingDistance;
        _rankData.Players.Add(player);
        _rankData.Players = _rankData.Players.OrderByDescending(player => player.MovingDistance).ToList();
        string json = JsonUtility.ToJson(_rankData);
        PlayerPrefs.SetString("LeaderBoard", json);
    }
    public void LeaderBoardReset()
    {
        _rankData.Players.Clear();
        PlayerPrefs.DeleteKey("LeaderBoard");
    }
}
[Serializable]
public class RankData
{
    public List<Player> Players = new List<Player>();
}
[Serializable]
public struct Player
{
    public string Name;
    public float MovingDistance;
}