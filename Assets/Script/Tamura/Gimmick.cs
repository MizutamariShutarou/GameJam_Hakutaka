using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using System;

/// <summary>ランダムでなにかが起こる</summary>
public class Gimmick : MonoBehaviour
{
    //--カメラが切り替わるギミック関係--//
    [Header("カメラが切り替わるギミック関係")]
    [SerializeField] private CinemachineVirtualCamera[] _cameras = new CinemachineVirtualCamera[0];
    private int _unSelectPriority = 1;
    private int _selectPriority = 100;
    private int _currentCamera = 0;

    //--なにかが通りかかるギミック関係--//
    [Header("なにかが通りかかるギミック関係")]
    [SerializeField, Header("通りかかるなにか")] private GameObject _throughGameObject = default;
    [SerializeField] private float _moveSecond = 5;

    //--暗くなるギミック関係--//
    [Header("暗くなるギミック関係")]
    [SerializeField, Header("この世界の光")] private Light _light = default;
    [SerializeField, Header("小さいほど暗い"), Range(0, 50)] private float _lightRotate = 10;
    [SerializeField, Header("どのくらいかけて暗くなるか")] private float _toDarkSecond = 3;

    [Header("時間関係")]
    private Action[] _gimmicks = new Action[2];
    [SerializeField, Header("イベントのクールタイム")] private float _coolTime = 25f;
    [SerializeField, Header("クールタイム最小値")] private float _minValue = 2;
    [SerializeField, Header("クールタイム最大値")] private float _maxValue = 2;
    [SerializeField] private float _timer = 0;

    private void Start()
    {
        //配列にギミックの関数を入れていく
        _gimmicks[0] = ChangeCamera;
        _gimmicks[1] = PassThrough;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        //時間になったらランダムにイベントが起こる
        if (_timer > _coolTime)
        {
            _gimmicks[UnityEngine.Random.Range(0, _gimmicks.Length)]();
            _coolTime = UnityEngine.Random.Range(_minValue, _maxValue);
            _timer = 0;
        }

    }

    /// <summary>
    /// カメラが切り替わる
    /// </summary>
    public void ChangeCamera()
    {
        //今のカメラを非選択にする
        _cameras[_currentCamera].Priority = _unSelectPriority;
        _currentCamera++;

        if(_currentCamera >= _cameras.Length)
        {
            _currentCamera = 0;
        }

        //カメラを切り替える
        _cameras[_currentCamera].Priority = _selectPriority;
    }

    /// <summary>
    /// なにかが通りかかる
    /// </summary>
    public void PassThrough()
    {
        var go = Instantiate(_throughGameObject, new Vector3(-700, 0, 36), Quaternion.identity);
        go.transform.DOMoveX(700, _moveSecond).SetEase(Ease.Linear).OnComplete(() => Destroy(go)).SetAutoKill();
    }

    /// <summary>
    /// 暗くなる
    /// </summary>
    public void ToDark()
    {
        _light.transform.DORotate(new Vector3(_lightRotate, -30, 0), _toDarkSecond)
            .SetEase(Ease.Linear).SetAutoKill();
    }

}
