using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数式生成に関するスクリプト
/// </summary>
public class CalculationQuestionGenerator : MonoBehaviour
{
    [SerializeField, Header("難易度調整")] private LevelParameter[] _levelParameter = new LevelParameter[0];
    private int _nowLevel = 0;
    private int _minValue = 0;
    private int _maxValue = 10;
    private bool _isAppearMultiplication = false;

    [SerializeField, Header("最初に生成される問題の数")] private int _firstGenerateNumber = 4;
    private List<int> _leftNumbers = new List<int>();
    private List<int> _rightNumbers = new List<int>();
    private List<string> _symbols = new List<string>();
    private List<int> _answers = new List<int>();
    private int _answerCount = 0;

    /// <summary>最初に生成される問題の数</summary>
    public int FirstGenerateNumber => _firstGenerateNumber;
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

        //あらかじめいくつか問題を作っておく
        for (int i = 0; i < _firstGenerateNumber; i++)
        {
            QuestionGenerate();
        }

        LevelUp();
    }

    /// <summary>
    /// 問題を生成する
    /// </summary>
    private void QuestionGenerate()
    {
        //2つの数値をランダムに決める
        int leftNumber = Random.Range(_minValue, _maxValue);
        int rightNumber = Random.Range(_minValue, _maxValue);
        string symbol = "";
        int answer = default;

        //記号をランダムに決める
        //自動的に答えも決まる
        switch (Random.Range(0, _isAppearMultiplication ? 3 : 2))
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

        Debug.Log($"{leftNumber} {symbol} {rightNumber} = {answer}");
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

        if(_nowLevel < _levelParameter.Length && _answerCount >= _levelParameter[_nowLevel].NextBorder)
        {
            LevelUp();
        }

    }

    //難易度が上がるときに数値を入れ替える
    private void LevelUp()
    {
        Debug.Log("レベルが上がったよ");
        var tmp = _levelParameter[_nowLevel];
        _minValue = tmp.MinValue;
        _maxValue = tmp.MaxValue;
        _isAppearMultiplication = tmp.IsAppearMultiplication;
        _nowLevel++;
    }

}

[System.Serializable]
class LevelParameter
{
    [Header("次のレベルに行くための問題数"), SerializeField] int nextBorder;
    [Header("出てくる数値の最小値"), SerializeField ,Range(0, 10)] int minValue;
    [Header("出てくる数値の最大値"), SerializeField ,Range(0, 10)] int maxValue;
    [Header("掛け算がでるかどうか"), SerializeField] bool isAppearMultiplication;

    public int NextBorder => nextBorder;
    public int MinValue => minValue;
    public int MaxValue => maxValue;
    public bool IsAppearMultiplication => isAppearMultiplication;
}