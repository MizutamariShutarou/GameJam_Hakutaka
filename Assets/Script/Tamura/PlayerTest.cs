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
        }
        else
        {
            Debug.Log("不正解…");
        }

        //答えたよってしてる
        _questionGenerator.Answer();
    }

}
