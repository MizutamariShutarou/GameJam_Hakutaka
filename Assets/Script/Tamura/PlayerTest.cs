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
    [SerializeField] private int _answerCount = 0;

    private void Start()
    {
        _inputField.Select();
    }

    private void Update()
    {
        //if (_inputField.isFocused) return;
        //_inputField.Select();
    }

    public async void OnEndEdit()
    {
        //何も入力されてなかったら何もしない
        if (_inputField.text == "") return;

        _answerCount++;
        int playerAnswer = int.Parse(_inputField.text);
        _inputField.text = "";

        //答えの判定
        if(playerAnswer == _questionGenerator.NowAnswer)
        {
            Debug.Log("正解！");
            AudioManager.Instance.PlaySE(1);
            _trainManager.Correct();
            _calculationUI.ActiveCorrectImage();
        }
        else
        {
            Debug.Log("不正解…");
            AudioManager.Instance.PlaySE(2);
            _trainManager.Incorrect();
            _calculationUI.ActiveIncorrectImage();
        }

        //答えたよってしてる
        _questionGenerator.Answer(_answerCount);
        _trainManager.ChangeSpeedRate(_answerCount);
        await _calculationUI.UpdateUI(_questionGenerator.CurrentNum - 1);
    }

}
