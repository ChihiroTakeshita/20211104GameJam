using System.Collections;
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
    [SerializeField] GameObject _pauseDisplay;
    [SerializeField] Scene _titleScene;
    Scene _nowScene;
    [SerializeField] Scene _endScene;
    [SerializeField] float _endWaitTime;
    [SerializeField] Text _endText;
    [SerializeField] GameObject _endCanvas;
    [SerializeField] GameObject _fadeImage;
    Image _fade;
    [SerializeField] float _chengeTime;

    // Start is called before the first frame update
    void Start()
    {
        _fade = _fadeImage.GetComponent<Image>();
        _nowScene = SceneManager.GetActiveScene();
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
        _OnPauseEvent();
        _pause = true;
        _pauseDisplay.SetActive(true);
    }

    public void Resume()
    {
        _OnResumeEvent();
        _pause = false;
        _pauseDisplay.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(_titleScene.handle);
    }

    public void Restart()
    {
        SceneManager.LoadScene(_nowScene.handle);
    }

    public void Death()
    {
        SceneManager.LoadScene(_nowScene.handle);
    }

    public void Goal()
    {
        _endCanvas.SetActive(true);
        _endText.text = $"{_nowScene.name}\nClear";
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
