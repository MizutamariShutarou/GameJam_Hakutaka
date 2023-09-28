using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 駅を定期的に生み出す
/// </summary>
public class SpawnStation : MonoBehaviour
{
    [SerializeField] private TrainManager _trainManager = default;
    [SerializeField] private GameObject _station = default;
    [SerializeField] private Transform _spawnPoint = default;
    [SerializeField, Header("駅のオブジェクトが消える場所")] private float _destroyStationZ = -600;
    [SerializeField, Header("スクロールするスピードにかかる係数")] private float _speedCoe = 30f;
    [SerializeField] private GameObject _spawnedStation = null;
    [SerializeField] private float _spawnDistance = 100;
    [SerializeField, Header("駅が出てくる場所")] private float[] _stationPoint = new float[4];
    private bool _isThrowAllStation = false;
    private int _stationCount = 0;

    void Start()
    {
        _spawnDistance = _stationPoint[0];
    }

    void Update()
    {
        //全ての駅を通り過ぎてたらなにもしない
        if (_isThrowAllStation) return;

        //設定した駅の間隔ごとに出現する
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

        //背景より駅のほうが近いから、背景よりも早くスクロールしたほうがいいよね
        float moveSpeed = _trainManager._currentSpeed / 60 * Time.deltaTime * _speedCoe;
        _spawnedStation.transform.position += new Vector3(0, 0, -moveSpeed);

        if(_spawnedStation.transform.position.z < _destroyStationZ)
        {
            Destroy(_spawnedStation);
            _spawnedStation = null;
        }

    }
}
