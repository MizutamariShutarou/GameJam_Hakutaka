using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource _bgm;
    [SerializeField] AudioSource _loop;
    [SerializeField] AudioSource _se;
    [SerializeField] AudioClip[] _bgmClips;
    [SerializeField] AudioClip[] _loopClips;
    [SerializeField] AudioClip[] _seClips;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySE(int index)
    {
        _se.PlayOneShot(_seClips[index]);
    }
    public void PlayBGM(int index)
    {
        _bgm.clip = _bgmClips[index];
        _bgm.Play();
    }
    public void PauseBGM()
    {
        _bgm.Pause();
    }
    public void UnPauseBGM()
    {
        _bgm.UnPause();
    }
    public void StopBGM()
    {
        _bgm.Stop();
    }
    public void PlayLoop(int index)
    {
        _loop.clip = _loopClips[index];
        _loop.Play();
    }
    public void StopLoop()
    {
        _loop.Stop();
    }
}
