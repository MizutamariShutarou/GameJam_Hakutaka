using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    [SerializeField]
    private float _fadeSpeed = 0f;

    [SerializeField]
    private Ease _fadeEase = Ease.Linear;

    [SerializeField]
    private float _endPos = 0f;

    private List<OperationObj> _operationObjList = new List<OperationObj>();

    // private CancellationToken _ct = new CancellationToken();

    void Start()
    {
        // _ct = this.GetCancellationTokenOnDestroy();
        for (int i = 0; i < _generator.FirstGenerateNumber; i++)
        {
            SettingUI(i);
        }
    }

    private void SettingUI(int num)
    {
        var obj = GameObject.Instantiate(_operationObj, _canvas.transform);
        _operationObjList.Add(obj);
        obj.Initialize(_generator, num);
    }

    public async UniTask UIAnimation(List<OperationObj> objList)
    {
        var image = objList[0].GetComponent<Image>();

        var seq = DOTween.Sequence();

        seq
            .Join(image.DOFade(0f, _fadeSpeed).SetEase(_fadeEase))
            .Join(objList[0].transform.DOLocalMoveX(_endPos, _fadeSpeed).SetEase(_fadeEase))
            .OnComplete(() =>
            {
                DestroyUIObj();
            });

        await UniTask.CompletedTask;
    }

    private void DestroyUIObj()
    {
        Destroy(_operationObjList[0].gameObject);
        _operationObjList.RemoveAt(0);
    }

    public async UniTask UpdateUI(int currentNum)
    {
        SettingUI(currentNum);

        await UIAnimation(_operationObjList);
    }

}
