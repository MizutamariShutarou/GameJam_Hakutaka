using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数式生成に関するスクリプト
/// </summary>
public class CalculationQuestionGenerator : MonoBehaviour
{
    private List<int> _leftNumbers = new List<int>();
    private List<int> _rightNumbers = new List<int>();
    private List<string> _symbols = new List<string>();
    private List<int> _answers = new List<int>();
    private int _answerCount = 0;

    /// <summary>数式の左側の数字たち</summary>
    public List<int> LeftNumbers => _leftNumbers;
    /// <summary>数式の右側の数字たち</summary>
    public List<int> RightNumbers => _rightNumbers;
    /// <summary>数式の記号たち</summary>
    public List<string> Symbols => _symbols;
    /// <summary>数式の答えたち</summary>
    public List<int> Answers => _answers;
    /// <summary>今の問題の答え</summary>
    public int NowAnswer => _answers[_answerCount];

    void Start()
    {

        //あらかじめ4つ問題を作っておく
        for (int i = 0; i < 4; i++)
        {
            QuestionGenerate();
        }

    }

    /// <summary>
    /// 問題を生成する
    /// </summary>
    private void QuestionGenerate()
    {
        //2つの数値をランダムに決める
        int leftNumber = Random.Range(0, 9);
        int rightNumber = Random.Range(0, 9);
        string symbol = "";
        int answer = default;

        //記号をランダムに決める
        //自動的に答えも決まる
        switch (Random.Range(0, 3))
        {
            case 0:
                symbol = "＋";
                answer = leftNumber + rightNumber;
                break;

            case 1:
                symbol = "ー";

                //答えがマイナスにならないように調整
                if(rightNumber > leftNumber)
                {
                    int tmp = rightNumber;
                    rightNumber = leftNumber;
                    leftNumber = tmp;
                }

                answer = leftNumber - rightNumber;
                break;

            case 2:
                symbol = "×";
                answer = leftNumber * rightNumber;
                break;

            default:
                break;
        }

        //それぞれをリストに追加する
        _leftNumbers.Add(leftNumber);
        _rightNumbers.Add(rightNumber);
        _symbols.Add(symbol);
        _answers.Add(answer);
    }

    /// <summary>
    /// プレイヤーが答えたときに行う処理
    /// 新しく問題を追加する
    /// </summary>
    public void Answer()
    {
        Debug.Log("問題に答えたよ");
        QuestionGenerate();
        _answerCount++;
    }

}
