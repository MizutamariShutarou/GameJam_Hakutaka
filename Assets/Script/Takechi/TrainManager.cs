using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class TrainManager : MonoBehaviour, IManager
{
    [SerializeField] float _increaseSpeed = 5;
    [SerializeField] float _decreaseSpeed = 2;
    [SerializeField] float _initialSpeed = 10;
    internal float _currentSpeed { get; private set; } = 0;
    public static float _movingDistance { get; private set; } = 0;
    float _elapsedTime = 0;

    [Header("スピードの変化量について")]
    [SerializeField, Header("指数関数を使うかどうか")] private bool _isUseS = true;

    //--指数関数バージョン--//
    [SerializeField, Header("指数関数のnの部分")] private float _coeS = 2;

    //--一次関数バージョン--//
    [SerializeField, Header("一次関数のnの部分")] private float _coeI = 5;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        _movingDistance += _currentSpeed * Time.deltaTime / 60;
        _elapsedTime += Time.deltaTime;
    }
    public void Initialize()
    {
        _currentSpeed = _initialSpeed;
        _movingDistance = 0;
    }

    public void Correct()
    {
        _currentSpeed += _increaseSpeed;
    }

    public void Incorrect()
    {
        _currentSpeed -= _decreaseSpeed;
        if( _currentSpeed <= 0 )
        {
            _currentSpeed = 0;
        }
    }

    public void ChangeSpeedRate(int answerCount)
    {

        //指数関数使います
        if (_isUseS)
        {
            _increaseSpeed = Mathf.Pow(_coeS, answerCount);
            _decreaseSpeed = Mathf.Pow(_coeS, answerCount);
        }
        //一次関数使います
        else
        {
            _increaseSpeed = _coeI * answerCount;
            _decreaseSpeed = _coeI * answerCount;
        }

    }

}
