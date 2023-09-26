using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationObj : MonoBehaviour
{
    public void Initialize(CalculationQuestionGenerator gen, int num)
    {
        var text = this.GetComponentsInChildren<Text>();

        text[0].text = gen.LeftNumbers[num].ToString();
        text[1].text = gen.Symbols[num];
        text[2].text = gen.RightNumbers[num].ToString();
        text[3].text = "=";
        text[4].text = "?";

        Debug.Log($"{text[0].text} {text[1].text} {text[2].text} = ? ");
    }
}
