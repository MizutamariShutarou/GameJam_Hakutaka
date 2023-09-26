using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������Ɋւ���X�N���v�g
/// </summary>
public class CalculationQuestionGenerator : MonoBehaviour
{
    private List<int> _leftNumbers = new List<int>();
    private List<int> _rightNumbers = new List<int>();
    private List<string> _symbols = new List<string>();
    private List<int> _answers = new List<int>();
    private int _answerCount = 0;

    /// <summary>�����̍����̐�������</summary>
    public List<int> LeftNumbers => _leftNumbers;
    /// <summary>�����̉E���̐�������</summary>
    public List<int> RightNumbers => _rightNumbers;
    /// <summary>�����̋L������</summary>
    public List<string> Symbols => _symbols;
    /// <summary>�����̓�������</summary>
    public List<int> Answers => _answers;
    /// <summary>���̖��̓���</summary>
    public int NowAnswer => _answers[_answerCount];

    void Start()
    {

        //���炩����4��������Ă���
        for (int i = 0; i < 4; i++)
        {
            QuestionGenerate();
        }

    }

    /// <summary>
    /// ���𐶐�����
    /// </summary>
    private void QuestionGenerate()
    {
        //2�̐��l�������_���Ɍ��߂�
        int leftNumber = Random.Range(0, 9);
        int rightNumber = Random.Range(0, 9);
        string symbol = "";
        int answer = default;

        //�L���������_���Ɍ��߂�
        //�����I�ɓ��������܂�
        switch (Random.Range(0, 3))
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
    }

    /// <summary>
    /// �v���C���[���������Ƃ��ɍs������
    /// �V��������ǉ�����
    /// </summary>
    public void Answer()
    {
        Debug.Log("���ɓ�������");
        QuestionGenerate();
        _answerCount++;
    }

}
