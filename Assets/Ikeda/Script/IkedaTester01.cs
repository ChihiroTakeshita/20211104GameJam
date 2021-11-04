using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkedaTester01 : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager._OnPauseEvent += Pause;
        GameManager._OnResumeEvent += Resume;
    }

    private void OnDisable()
    {
        GameManager._OnPauseEvent -= Pause;
        GameManager._OnResumeEvent -= Resume;
    }

    public void Pause()
    {
        Debug.Log("Pause");
    }

    public void Resume()
    {
        Debug.Log("Resume");
    }
}
