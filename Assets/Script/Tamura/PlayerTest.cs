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
        //�������͂���ĂȂ������牽�����Ȃ�
        if (_inputField.text == "") return;

        _answerCount++;
        int playerAnswer = int.Parse(_inputField.text);
        _inputField.text = "";

        //�����̔���
        if(playerAnswer == _questionGenerator.NowAnswer)
        {
            Debug.Log("�����I");
            _trainManager.Correct();
        }
        else
        {
            Debug.Log("�s�����c");
            _trainManager.Incorrect();
        }

        //����������Ă��Ă�
        _questionGenerator.Answer(_answerCount);
        _trainManager.ChangeSpeedRate(_answerCount);
        await _calculationUI.UpdateUI(_questionGenerator.CurrentNum - 1);
    }

}
