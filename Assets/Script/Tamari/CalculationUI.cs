using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculationUI : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas = default;

    [SerializeField]
    private CalculationQuestionGenerator _generator = default;

    [SerializeField]
    private OperationObj _operationObj = default;

    private List<OperationObj> _operationObjList = new List<OperationObj>();

    void Start()
    {
        for(int i = 0; i < _generator.FirstGenerateNumber; i++)
        {
            var obj = GameObject.Instantiate(_operationObj, _canvas.transform);
            _operationObjList.Add(obj);
            obj.Initialize(_generator, i);
        }
    }

    public void SettingUI(int num)
    {
        var obj = GameObject.Instantiate(_operationObj, _canvas.transform);
        _operationObjList.Add(obj);
        obj.Initialize(_generator, num);
        _operationObjList.Remove(_operationObjList[_generator.CurrentNum - _generator.FirstGenerateNumber]);
    }
}
