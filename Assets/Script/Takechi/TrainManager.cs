using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class TrainManager : MonoBehaviour, IManager
{
    [SerializeField] float _increaseSpeed = 5;
    [SerializeField] float _decreaseSpeed = 2;
    [SerializeField] float _initialSpeed = 10;
    internal float _currentSpeed { get; private set; } = 0;
    internal static float _movingDistance { get; private set; } = 0;
    float _elapsedTime = 0;

    void Start()
    {
        _currentSpeed = _initialSpeed;
    }

    void Update()
    {
        _movingDistance += _currentSpeed * Time.deltaTime / 60;
        _elapsedTime += Time.deltaTime;
    }
    internal void Initialize()
    {
        _currentSpeed = _initialSpeed;
    }

    internal void Correct()
    {
        _currentSpeed += _increaseSpeed;
    }

    internal void Incorrect()
    {
        _currentSpeed -= _decreaseSpeed;
        if( _currentSpeed <= 0 )
        {
            _currentSpeed = 0;
        }
    }
}
