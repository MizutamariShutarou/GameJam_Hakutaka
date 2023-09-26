using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 入力関連のテストしたい
/// </summary>
public class PlayerTest : MonoBehaviour
{
    [SerializeField] private InputField _inputField = default;
    [SerializeField] private CalculationQuestionGenerator _questionGenerator = default;
    [SerializeField] private CalculationUI _calculationUI = default;
    [SerializeField] private TrainManager _trainManager = default;

    private void Start()
    {
        _inputField.Select();
    }

    private void Update()
    {
        //if (_inputField.isFocused) return;
        //_inputField.Select();
    }

    public void OnEndEdit()
    {
        //何も入力されてなかったら何もしない
        if (_inputField.text == "") return;

        int playerAnswer = int.Parse(_inputField.text);
        _inputField.text = "";

        //答えの判定
        if(playerAnswer == _questionGenerator.NowAnswer)
        {
            Debug.Log("正解！");
            _trainManager.Correct();
        }
        else
        {
            Debug.Log("不正解…");
            _trainManager.Incorrect();
        }

        //答えたよってしてる
        _questionGenerator.Answer();
        _calculationUI.SettingUI(_questionGenerator.CurrentNum - 1);
    }

}
