using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ResultText : MonoBehaviour
{
    [SerializeField] TextType _textType;
    ResultManager _resultManager;
    Text _text;
    void Start()
    {
        _text = GetComponent<Text>();
        _resultManager = FindObjectOfType<ResultManager>();
    }

    void Update()
    {
        if(_textType == TextType.MovingDistance)
            _text.text = $"�i�񂾋����F{TrainManager._movingDistance}km";
        if (_textType == TextType.TransitStaion)
            _text.text = $"�I���w�F{_resultManager._transitStaion}";
    }
    enum TextType
    {
        MovingDistance,
        TransitStaion,
        CorrectCount,
        MaxSpeed,
    }
}
