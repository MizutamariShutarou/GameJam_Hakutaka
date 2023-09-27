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
    private GameObject _spawnedStation = null;
    [SerializeField] private float _spawnDistance = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
        //��U50km���ɃX�|�[��������
        if(TrainManager._movingDistance > _spawnDistance)
        {
            _spawnedStation = Instantiate(_station, _spawnPoint);
            _spawnDistance += 50;
        }

        if (!_spawnedStation) return;

        //�w�i���w�̂ق����߂�����A�w�i���������X�N���[�������ق����������
        float moveSpeed = _trainManager._currentSpeed * Time.deltaTime * _speedCoe;
        _spawnedStation.transform.position += new Vector3(0, 0, -moveSpeed);

        if(_spawnedStation.transform.position.z < _destroyStationZ)
        {
            Destroy(_spawnedStation);
            _spawnedStation = null;
        }

    }
}
