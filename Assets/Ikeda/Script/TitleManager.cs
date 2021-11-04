using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Scene _gameScene;

    public void SceneChange()
    {
        SceneManager.LoadScene(_gameScene.handle);
    }
}
