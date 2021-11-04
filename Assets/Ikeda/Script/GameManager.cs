using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action _OnPause;
    public static Action _OnResume;
    bool _pause;
    [SerializeField] GameObject _pauseDisplay;
    [SerializeField] Scene _titleScene;
    Scene _nowScene;
    [SerializeField] Scene _endScene;
    [SerializeField] float _endWaitTime;

    // Start is called before the first frame update
    void Start()
    {
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
    void Pause()
    {
        _OnPause();
        _pause = true;
        _pauseDisplay.SetActive(true);
    }

    void Resume()
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
        SceneManager.LoadScene(_nowScene.handle);
    }

    public void Death()
    {
        SceneManager.LoadScene(_nowScene.handle);
    }

    public void Goal()
    {
        StartCoroutine(EndStay());
    }

    IEnumerator EndStay()
    {
        yield return new WaitForSeconds(_endWaitTime);
        SceneManager.LoadScene(_endScene.handle);
    }
}
