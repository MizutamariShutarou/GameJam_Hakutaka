using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] CanvasGroup[] _panels;
    Tween _tween;
    void Start()
    {
        ChangePanel(0);
    }
    public void ChangePanel(int index)
    {
        if (_panels.Count() < 1) return;
        foreach (var panel in _panels)
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        _panels[index].alpha = 1;
        _panels[index].interactable = true;
        _panels[index].blocksRaycasts = true;
    }
    public void LoadScene(string sceneName)
    {
        if (_tween != null) return;
        Image fadePanel = transform.Find("Fade").GetComponent<Image>();
        if (fadePanel == null) return;
        _tween = fadePanel.DOFade(1, 2).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
