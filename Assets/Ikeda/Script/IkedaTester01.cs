using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkedaTester01 : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager._OnPause += Pause;
        GameManager._OnResume += Resume;
    }

    private void OnDisable()
    {
        GameManager._OnPause -= Pause;
        GameManager._OnResume -= Resume;
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
