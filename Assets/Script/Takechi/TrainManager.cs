using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour, IManager
{
    [SerializeField] float _increaseSpeed = 5;
    [SerializeField] float _decreaseSpeed = 2;
    [SerializeField] float _initialSpeed = 10;
    public float _currentSpeed { get; private set; } = 0;
    public float _movingDistance { get; private set; } = 0;
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
    public void Initialize()
    {
        _currentSpeed = _initialSpeed;
    }

    public void Correct()
    {
        _currentSpeed += _increaseSpeed;
    }

    public void Incorrect()
    {
        _currentSpeed -= _decreaseSpeed;
    }
}
