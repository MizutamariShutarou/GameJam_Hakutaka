using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardDisplay : MonoBehaviour
{
    [SerializeField] Text _text;
    LeaderBoard _leaderBoard;
    List<Text> _list = new List<Text>();
    void Start()
    {
        _leaderBoard = FindObjectOfType<LeaderBoard>();
        PlayerEntry();
    }
    public void PlayerEntry()
    {
        if(_list.Count > 0)
        {
            foreach (var item in _list)
            {
                Destroy(item.gameObject);
            }
            _list.Clear();
        }
        foreach (var player in _leaderBoard._rankData.Players)
        {
            Text text = Instantiate(_text, transform);
            text.text = $"{player.Name}: {player.MovingDistance.ToString("0.000")}km";
            _list.Add(text);
        }
    }
    public void LeaderBoardReset()
    {
        if (_list.Count > 0)
        {
            foreach (var item in _list)
            {
                Destroy(item.gameObject);
            }
            _list.Clear();
        }
    }
}
