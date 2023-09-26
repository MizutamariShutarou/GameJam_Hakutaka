using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IManager
{
    [SerializeField] int _increaseScore = 100;
    [SerializeField] int _decreaseScore = 50;
    int _score = 0;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Initialize()
    {
        _score = 0;
    }

    public void Correct()
    {
        _score += _increaseScore;
    }

    public void Incorrect()
    {
        _score -= _decreaseScore;
    }
}
