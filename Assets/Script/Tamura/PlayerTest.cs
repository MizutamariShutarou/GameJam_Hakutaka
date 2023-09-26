using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���͊֘A�̃e�X�g������
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
        //�������͂���ĂȂ������牽�����Ȃ�
        if (_inputField.text == "") return;

        int playerAnswer = int.Parse(_inputField.text);
        _inputField.text = "";

        //�����̔���
        if(playerAnswer == _questionGenerator.NowAnswer)
        {
            Debug.Log("�����I");
        }
        else
        {
            Debug.Log("�s�����c");
        }

        //����������Ă��Ă�
        _questionGenerator.Answer();
    }

}
