using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
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

    [Header("計算式UI関連のパラ")]

    [SerializeField]
    private float _fadeSpeed = 0f;

    [SerializeField]
    private Ease _fadeEase = Ease.Linear;

    [SerializeField]
    private float _fadeOutMoveEndPos = 0f;

    [SerializeField]
    private float _nextUISize = 0f;

    [Header("正解不正解UI関連のパラ")]

    [SerializeField]
    private Image _upImage = default;

    [SerializeField]
    private Image _downImage = default;

    [SerializeField]
    private float _delayTime = default;

    //[SerializeField]
    //private float _imageFadeSpeed = 0f;

    //[SerializeField]
    //private Ease _imageFadeEase = Ease.Linear;

    private CancellationToken _ct = new CancellationToken();

    private List<OperationObj> _operationObjList = new List<OperationObj>();

    void Start()
    {
        _ct = this.GetCancellationTokenOnDestroy();
        _upImage.gameObject.SetActive(false);
        _downImage.gameObject.SetActive(false);
        for (int i = 0; i < _generator.FirstGenerateNumber; i++)
        {
            SettingUI(i).Forget();
        }
    }

    private void Update()
    {
        SettingNextUI();
    }

    private async UniTask SettingUI(int num)
    {
        var obj = GameObject.Instantiate(_operationObj, _canvas.transform);
        _operationObjList.Add(obj);
        obj.Initialize(_generator, num);
        await UniTask.CompletedTask;
    }

    public void SettingNextUI()
    {
        var firstObj = _operationObjList[0].gameObject;
        firstObj.transform.localScale = new Vector3(1, 1, 1);

        var secondObj = _operationObjList[1].gameObject;
        secondObj.transform.localScale = new Vector3(_nextUISize, _nextUISize, _nextUISize);

        var thirdObj = _operationObjList[2].gameObject;
        thirdObj.transform.localScale = new Vector3(_nextUISize, _nextUISize, _nextUISize);
    }

    public async UniTask UIAnimation(List<OperationObj> objList)
    {
        var image = objList[0].GetComponent<Image>();

        var seq = DOTween.Sequence();

        seq
            .Join(image.DOFade(0f, _fadeSpeed).SetEase(_fadeEase))
            .Join(objList[0].transform.DOLocalMoveX(_fadeOutMoveEndPos, _fadeSpeed).SetEase(_fadeEase))
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
        await SettingUI(currentNum);

        await UIAnimation(_operationObjList);
    }

    public async void ActiveCorrectImage()
    {
        _upImage.gameObject.SetActive(true);
        await UniTask.Delay(TimeSpan.FromSeconds(_delayTime), cancellationToken: _ct);
        _upImage.gameObject.SetActive(false);
        //var seq = DOTween.Sequence();

        //seq
        //    .Join(_upImage.DOFade(1f, _imageFadeSpeed).SetEase(_imageFadeEase))
        //    .SetDelay(_delayTime)
        //    .Append(_upImage.DOFade(0f, _imageFadeSpeed).SetEase(_imageFadeEase));
    }

    public async void ActiveIncorrectImage()
    {
        _downImage.gameObject.SetActive(true);
        await UniTask.Delay(TimeSpan.FromSeconds(_delayTime), cancellationToken: _ct);
        _downImage.gameObject.SetActive(false);
        //var seq = DOTween.Sequence();

        //seq
        //    .Join(_downImage.DOFade(1f, _imageFadeSpeed).SetEase(_imageFadeEase))
        //    .SetDelay(_delayTime)
        //    .Append(_downImage.DOFade(0f, _imageFadeSpeed).SetEase(_imageFadeEase));
    }

}
