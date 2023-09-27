using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private TrainManager _trainManager = default;
    void Start()
    {
        _trainManager.Initialize();
    }
}
