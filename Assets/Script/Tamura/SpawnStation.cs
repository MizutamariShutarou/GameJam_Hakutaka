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
    private GameObject _spawnedStation = null;
    [SerializeField] private float _spawnDistance = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
        //一旦50km毎にスポーンさせる
        if(TrainManager._movingDistance > _spawnDistance)
        {
            _spawnedStation = Instantiate(_station, _spawnPoint);
            _spawnDistance += 50;
        }

        if (!_spawnedStation) return;

        //背景より駅のほうが近いから、背景よりも早くスクロールしたほうがいいよね
        float moveSpeed = _trainManager._currentSpeed * Time.deltaTime * _speedCoe;
        _spawnedStation.transform.position += new Vector3(0, 0, -moveSpeed);

        if(_spawnedStation.transform.position.z < _destroyStationZ)
        {
            Destroy(_spawnedStation);
            _spawnedStation = null;
        }

    }
}
