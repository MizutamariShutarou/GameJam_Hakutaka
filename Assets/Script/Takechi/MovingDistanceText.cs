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
        _text.text = $"�����F{TrainManager._movingDistance.ToString("0.000")}km\n���x�F{_trainManager._currentSpeed}km/h";
    }
}
