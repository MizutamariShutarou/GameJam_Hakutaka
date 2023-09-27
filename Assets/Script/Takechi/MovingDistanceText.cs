using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingDistanceText : MonoBehaviour
{
    [SerializeField] TextType _textType;
    TrainManager _trainManager;
    Text _text;
    void Start()
    {
        _trainManager = FindObjectOfType<TrainManager>();
        _text = GetComponent<Text>();
    }

    void Update()
    {
        if(_textType == TextType.MovingDistance)
            _text.text = TrainManager._movingDistance.ToString("0.000") + "km";
        if (_textType == TextType.Speed)
            _text.text = _trainManager._currentSpeed.ToString() + "km/h";
    }
    enum TextType
    {
        MovingDistance,
        Speed,
    }
}
