using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    /// <summary>key‚É‰w‚Ì‹——£Avalue‚É‰w–¼</summary>
    [SerializeField] SerializableKeyPair<float, string>[] _serializableStationRange;
    /// <summary>key‚É‰w‚Ì‹——£Avalue‚É‰w–¼</summary>
    Dictionary<float, string> _stationRange = new Dictionary<float, string>();
    /// <summary>’Ê‰ß‰w–¼</summary>
    public string _transitStaion { get; private set; }
    void Start()
    {
        _stationRange = _serializableStationRange.ToDictionary(pair => pair.Key, pair => pair.Value);
        _stationRange = _stationRange.OrderBy(a => a.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
        // ƒV[ƒ““Ç‚İ‚İ‚É’Ê‰ß‰w‚ğŠm”F‚·‚é
        _transitStaion = CheckStation(TrainManager._movingDistance);
    }
    public string CheckStation(float movingDistance)
    {
        string result = string.Empty;
        foreach (var station in _stationRange)
        {
            if (movingDistance >= station.Key)
            {
                result = station.Value;
            }
        }
        //Debug.Log(result);
        return result;
    }
}
[Serializable]
public class SerializableKeyPair<TKey, TValue>
{
    [SerializeField] private TKey key;
    [SerializeField] private TValue value;

    public TKey Key => key;
    public TValue Value => value;
}