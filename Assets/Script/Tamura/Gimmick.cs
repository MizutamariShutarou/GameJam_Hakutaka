using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using System;

/// <summary>�����_���łȂɂ����N����</summary>
public class Gimmick : MonoBehaviour
{
    //--�J�������؂�ւ��M�~�b�N�֌W--//
    [Header("�J�������؂�ւ��M�~�b�N�֌W")]
    [SerializeField] private CinemachineVirtualCamera[] _cameras = new CinemachineVirtualCamera[0];
    private int _unSelectPriority = 1;
    private int _selectPriority = 100;
    private int _currentCamera = 0;

    //--�Ȃɂ����ʂ肩����M�~�b�N�֌W--//
    [Header("�Ȃɂ����ʂ肩����M�~�b�N�֌W")]
    [SerializeField, Header("�ʂ肩����Ȃɂ�")] private GameObject _throughGameObject = default;
    [SerializeField] private float _moveSecond = 5;

    //--�Â��Ȃ�M�~�b�N�֌W--//
    [Header("�Â��Ȃ�M�~�b�N�֌W")]
    [SerializeField, Header("���̐��E�̌�")] private Light _light = default;
    [SerializeField, Header("�������قǈÂ�"), Range(0, 50)] private float _lightRotate = 10;
    [SerializeField, Header("�ǂ̂��炢�����ĈÂ��Ȃ邩")] private float _toDarkSecond = 3;

    [Header("���Ԋ֌W")]
    private Action[] _gimmicks = new Action[2];
    [SerializeField, Header("�C�x���g�̃N�[���^�C��")] private float _coolTime = 25f;
    [SerializeField, Header("�N�[���^�C���ŏ��l")] private float _minValue = 2;
    [SerializeField, Header("�N�[���^�C���ő�l")] private float _maxValue = 2;
    [SerializeField] private float _timer = 0;

    private void Start()
    {
        //�z��ɃM�~�b�N�̊֐������Ă���
        _gimmicks[0] = ChangeCamera;
        _gimmicks[1] = PassThrough;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        //���ԂɂȂ����烉���_���ɃC�x���g���N����
        if (_timer > _coolTime)
        {
            _gimmicks[UnityEngine.Random.Range(0, _gimmicks.Length)]();
            _coolTime = UnityEngine.Random.Range(_minValue, _maxValue);
            _timer = 0;
        }

    }

    /// <summary>
    /// �J�������؂�ւ��
    /// </summary>
    public void ChangeCamera()
    {
        //���̃J�������I���ɂ���
        _cameras[_currentCamera].Priority = _unSelectPriority;
        _currentCamera++;

        if(_currentCamera >= _cameras.Length)
        {
            _currentCamera = 0;
        }

        //�J������؂�ւ���
        _cameras[_currentCamera].Priority = _selectPriority;
    }

    /// <summary>
    /// �Ȃɂ����ʂ肩����
    /// </summary>
    public void PassThrough()
    {
        var go = Instantiate(_throughGameObject, new Vector3(-700, 0, 36), Quaternion.identity);
        go.transform.DOMoveX(700, _moveSecond).SetEase(Ease.Linear).OnComplete(() => Destroy(go)).SetAutoKill();
    }

    /// <summary>
    /// �Â��Ȃ�
    /// </summary>
    public void ToDark()
    {
        _light.transform.DORotate(new Vector3(_lightRotate, -30, 0), _toDarkSecond)
            .SetEase(Ease.Linear).SetAutoKill();
    }

}
