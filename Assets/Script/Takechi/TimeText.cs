using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeText : MonoBehaviour
{
    TimeManager _timeManager;
    Text _text;
    void Start()
    {
        _timeManager = FindObjectOfType<TimeManager>();
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = _timeManager._timer.ToString("0.00");
    }
}
