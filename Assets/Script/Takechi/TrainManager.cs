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

    [Header("�X�s�[�h�̕ω��ʂɂ���")]
    [SerializeField, Header("�w���֐����g�����ǂ���")] private bool _isUseS = true;

    //--�w���֐��o�[�W����--//
    [SerializeField, Header("�w���֐���n�̕���")] private float _coeS = 2;

    //--�ꎟ�֐��o�[�W����--//
    [SerializeField, Header("�ꎟ�֐���n�̕���")] private float _coeI = 5;

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

        //�w���֐��g���܂�
        if (_isUseS)
        {
            _increaseSpeed = Mathf.Pow(_coeS, answerCount);
            _decreaseSpeed = Mathf.Pow(_coeS, answerCount);
        }
        //�ꎟ�֐��g���܂�
        else
        {
            _increaseSpeed = _coeI * answerCount;
            _decreaseSpeed = _coeI * answerCount;
        }

    }

}
