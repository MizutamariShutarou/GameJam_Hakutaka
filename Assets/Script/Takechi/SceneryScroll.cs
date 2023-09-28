using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryScroll : MonoBehaviour
{
    [SerializeField, Header("スクロールスピードの係数")] private float _speedCoe = 10;
    [SerializeField] GameObject _scenery;
    Vector3 _frontAnchor, _backAnchor;
    float _distance;
    GameObject _scrollObject1;
    GameObject _scrollObject2;
    TrainManager _trainManager;
    void Start()
    {
        _trainManager = FindObjectOfType<TrainManager>();
        _scrollObject1 = GameObject.Find("Scenery");
        _frontAnchor = _scrollObject1.transform.Find("FrontAnchor").position;
        _backAnchor = _scrollObject1.transform.Find("BackAnchor").position;
        _distance = Vector3.Distance(_frontAnchor, _backAnchor);
        _scrollObject2 = Instantiate(_scenery, _scrollObject1.transform.position + new Vector3(0, 0, _distance), Quaternion.identity);
    }
    void Update()
    {
        float movingDistance = _trainManager._currentSpeed / 60 * Time.deltaTime * _speedCoe;
        _scrollObject1.transform.position += new Vector3(0, 0, -movingDistance);
        _scrollObject2.transform.position += new Vector3(0, 0, -movingDistance);
        if(_scrollObject1.transform.position.z < _backAnchor.z) 
            _scrollObject1.transform.position = _scrollObject2.transform.position + new Vector3(0, 0, _distance);
        if (_scrollObject2.transform.position.z < _backAnchor.z)
            _scrollObject2.transform.position = _scrollObject1.transform.position + new Vector3(0, 0, _distance);
    }
}