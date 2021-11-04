using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float _timer;
    [Tooltip("タイマー表示用テキスト")]
    [SerializeField]Text _text;
    bool isCount = true;
    public float _Timer { get { return _timer; } }

    private void Update()
    {
        if (isCount)
        {
            _timer += Time.deltaTime;
            _text.text = _timer.ToString("0.00");
        }
    }

    public void Stop()
    {
        isCount = false;
    }

    public void Start()
    {
        isCount = true;
    }

    private void OnEnable()
    {
        GameManager._OnPause += Stop;
        GameManager._OnResume += Start;
    }

    private void OnDisable()
    {
        GameManager._OnPause -= Stop;
        GameManager._OnResume -= Start;
    }
}
