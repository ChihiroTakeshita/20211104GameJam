using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkedaTester02 : MonoBehaviour
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

    }

    public void Resume()
    {

    }
}
