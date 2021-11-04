﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static event Action _OnPause;
    public static event Action _OnResume;
    bool _pause;
    [Tooltip("ikeda/PauseCamvasのインスタンスを入れる")]
    [SerializeField] GameObject _pauseDisplay;
    [Tooltip("タイトルシーンの番号")]
    [SerializeField] Scene _titleScene;
    string _nowScene;
    [Tooltip("クリア後に進むシーンの番号")]
    [SerializeField] Scene _endScene;
    [Tooltip("クリア時にフェードアウトまでの待機時間")]
    [SerializeField] float _endWaitTime;
    [Tooltip("ikeda/EndCanvasのインスタンス")]
    [SerializeField] GameObject _endCanvas;
    [Tooltip("EndCanvasのインスタンス下のテキスト")]
    [SerializeField] Text _endText;
    [Tooltip("EndCanvasのインスタンス下のイメージ")]
    [SerializeField] GameObject _fadeImage;
    Image _fade;
    [Tooltip("画面が白くなっていくのにかかる時間")]
    [SerializeField] float _chengeTime;
    [Tooltip("Timerコンポーネント")]
    [SerializeField] Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        _fade = _fadeImage.GetComponent<Image>();
        _nowScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (_pause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        _OnPause();
        _pause = true;
        _pauseDisplay.SetActive(true);
    }

    public void Resume()
    {
        _OnResume();
        _pause = false;
        _pauseDisplay.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(_titleScene.handle);
    }

    public void Restart()
    {
        SceneManager.LoadScene(_nowScene);
    }

    public void Death()
    {
        SceneManager.LoadScene(_nowScene);
    }

    public void Goal()
    {
        _endCanvas.SetActive(true);
        _timer.Stop();
        _endText.text = $"{_nowScene}  Clear\nClear  Time{_timer._Timer.ToString("0.00")}";
        StartCoroutine(EndStay());
    }

    IEnumerator EndStay()
    {
        yield return new WaitForSeconds(_endWaitTime);
        StartCoroutine(Fade());

    }
    IEnumerator Fade()
    {
        for(float t = 0; t <= _chengeTime; t += Time.deltaTime)
        {
            _fade.color = new Color(_fade.color.r, _fade.color.g, _fade.color.b, t / _chengeTime);
            yield return null;
        }
        SceneManager.LoadScene(_endScene.handle);
    }
}
