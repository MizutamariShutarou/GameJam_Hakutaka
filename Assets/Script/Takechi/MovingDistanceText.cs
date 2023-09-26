using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingDistanceText : MonoBehaviour
{
    TrainManager _trainManager;
    Text _text;
    void Start()
    {
        _trainManager = FindObjectOfType<TrainManager>();
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = $"ãóó£ÅF{TrainManager._movingDistance.ToString("0.000")}km\në¨ìxÅF{_trainManager._currentSpeed}km/h";
    }
}
