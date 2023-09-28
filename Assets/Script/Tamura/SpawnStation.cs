using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �w�����I�ɐ��ݏo��
/// </summary>
public class SpawnStation : MonoBehaviour
{
    [SerializeField] private TrainManager _trainManager = default;
    [SerializeField] private GameObject _station = default;
    [SerializeField] private Transform _spawnPoint = default;
    [SerializeField, Header("�w�̃I�u�W�F�N�g��������ꏊ")] private float _destroyStationZ = -600;
    [SerializeField, Header("�X�N���[������X�s�[�h�ɂ�����W��")] private float _speedCoe = 30f;
    [SerializeField] private GameObject _spawnedStation = null;
    [SerializeField] private float _spawnDistance = 100;
    [SerializeField, Header("�w���o�Ă���ꏊ")] private float[] _stationPoint = new float[4];
    private bool _isThrowAllStation = false;
    private int _stationCount = 0;

    void Start()
    {
        _spawnDistance = _stationPoint[0];
    }

    void Update()
    {
        //�S�Ẳw��ʂ�߂��Ă���Ȃɂ����Ȃ�
        if (_isThrowAllStation) return;

        //�ݒ肵���w�̊Ԋu���Ƃɏo������
        if(TrainManager._movingDistance > _spawnDistance)
        {
            _spawnedStation = Instantiate(_station, _spawnPoint);

            if (_stationCount < _stationPoint.Length)
            {
                _stationCount++;
                _spawnDistance = _stationPoint[_stationCount];
            }
            else
            {
                _isThrowAllStation = true;
            }

        }

        if (!_spawnedStation) return;

        //�w�i���w�̂ق����߂�����A�w�i���������X�N���[�������ق����������
        float moveSpeed = _trainManager._currentSpeed / 60 * Time.deltaTime * _speedCoe;
        _spawnedStation.transform.position += new Vector3(0, 0, -moveSpeed);

        if(_spawnedStation.transform.position.z < _destroyStationZ)
        {
            Destroy(_spawnedStation);
            _spawnedStation = null;
        }

    }
}
