using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityroom.Api;

/// <summary>
/// Unityroom�̃����L���O�V�X�e�����g��
/// </summary>
public class UnityroomRanking : MonoBehaviour
{
    void Start()
    {
        UnityroomApiClient.Instance.SendScore(1, TrainManager._movingDistance, ScoreboardWriteMode.HighScoreDesc);
    }

}
