using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������Ɋւ���X�N���v�g
/// </summary>
public class CalculationQuestionGenerator : MonoBehaviour
{
    [SerializeField, Header("�S�Ă̓�����'0'�ɂȂ�܂�")] private bool _isCheating = false;

    [SerializeField, Header("��Փx����")] private LevelParameter[] _levelParameter = new LevelParameter[0];
    [SerializeField] private int _nowLevel = 0;
    private int _minValue = 0;
    private int _maxValue = 10;
    private bool _isAppearMultiplication = false;

    [SerializeField, Header("�ŏ��ɐ����������̐�")] private int _firstGenerateNumber = 4;
    private List<int> _leftNumbers = new List<int>();
    private List<int> _rightNumbers = new List<int>();
    private List<string> _symbols = new List<string>();
    private List<int> _answers = new List<int>();
    //private int _answerCount = 0;
    private int _nowAnswer = 0;
    private int _currentNum = 0;

    /// <summary>�ŏ��ɐ����������̐�</summary>
    public int FirstGenerateNumber => _firstGenerateNumber;
    /// <summary>�����̍����̐�������</summary>
    public List<int> LeftNumbers => _leftNumbers;
    /// <summary>�����̉E���̐�������</summary>
    public List<int> RightNumbers => _rightNumbers;
    /// <summary>�����̋L������</summary>
    public List<string> Symbols => _symbols;
    /// <summary>�����̓�������</summary>
    public List<int> Answers => _answers;
    /// <summary>���݂̖�萔</summary>
    public int CurrentNum => _currentNum;
    /// <summary>���̖��̓���</summary>
    public int NowAnswer => _nowAnswer;

    void Awake()
    {

        //�`�[�g���[�h�ł�
        //if (_isCheating)
        //{
        //    Debug.Log("�`�[�g���[�h���L���ł�");
        //    _levelParameter[0].NextBorder = int.MaxValue;
        //    _levelParameter[0].MinValue = 0;
        //    _levelParameter[0].MaxValue = 0;
        //    _levelParameter[0].IsAppearMultiplication = false;
        //    _maxValue = 0;
        //}

        //���炩���߂�������������Ă���
        for (int i = 0; i < _firstGenerateNumber; i++)
        {
            QuestionGenerate();
        }

        _nowAnswer = _answers[0];
    }

    private void Start()
    {
        LevelUp();
    }

    /// <summary>
    /// ���𐶐�����
    /// </summary>
    private void QuestionGenerate()
    {
        _currentNum++;
        Debug.Log(_currentNum);
        //2�̐��l�������_���Ɍ��߂�
        int leftNumber = Random.Range(_minValue, _maxValue);
        int rightNumber = Random.Range(_minValue, _maxValue);
        string symbol = "";
        int answer = default;

        //�L���������_���Ɍ��߂�
        //�����I�ɓ��������܂�
        switch (Random.Range(0, _isAppearMultiplication ? 3 : 2))
        {
            case 0:
                symbol = "�{";
                answer = leftNumber + rightNumber;
                break;

            case 1:
                symbol = "�[";

                //�������}�C�i�X�ɂȂ�Ȃ��悤�ɒ���
                if(rightNumber > leftNumber)
                {
                    int tmp = rightNumber;
                    rightNumber = leftNumber;
                    leftNumber = tmp;
                }

                answer = leftNumber - rightNumber;
                break;

            case 2:
                symbol = "�~";
                answer = leftNumber * rightNumber;
                break;

            default:
                break;
        }

        //���ꂼ������X�g�ɒǉ�����
        _leftNumbers.Add(leftNumber);
        _rightNumbers.Add(rightNumber);
        _symbols.Add(symbol);
        _answers.Add(answer);

        Debug.Log($"{leftNumber} {symbol} {rightNumber} = {answer}");
    }

    /// <summary>
    /// �v���C���[���������Ƃ��ɍs������
    /// �V��������ǉ�����
    /// </summary>
    public void Answer(int answerCount)
    {
        Debug.Log("���ɓ�������");
        QuestionGenerate();
        _nowAnswer = _answers[answerCount];

        if(_nowLevel < _levelParameter.Length && answerCount == _levelParameter[_nowLevel].NextBorder)
        {
            LevelUp();
        }

    }

    //��Փx���オ��Ƃ��ɐ��l�����ւ���
    private void LevelUp()
    {
        Debug.Log("���x�����オ������");
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
    [Header("���̃��x���ɍs�����߂̖�萔"), SerializeField] int nextBorder;
    [Header("�o�Ă��鐔�l�̍ŏ��l"), SerializeField ,Range(0, 10)] int minValue;
    [Header("�o�Ă��鐔�l�̍ő�l"), SerializeField ,Range(0, 10)] int maxValue;
    [Header("�|���Z���ł邩�ǂ���"), SerializeField] bool isAppearMultiplication;

    public int NextBorder => nextBorder;
    public int MinValue => minValue;
    public int MaxValue => maxValue;
    public bool IsAppearMultiplication => isAppearMultiplication;
}