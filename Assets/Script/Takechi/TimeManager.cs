using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour, IManager
{
    [SerializeField] float _timeLimit;
    public float _timer { get; private set; } = 0;
    void Start()
    {
        _timer = _timeLimit;
    }
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0) SceneManager.LoadScene("Result");
    }
    public void Initialize()
    {
        _timer = _timeLimit;
    }

    public void Correct()
    {
    }

    public void Incorrect()
    {
    }
}
