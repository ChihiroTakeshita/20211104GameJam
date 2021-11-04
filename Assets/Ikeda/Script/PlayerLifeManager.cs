using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeManager : MonoBehaviour
{

    [Tooltip("スタート時の残機")]
    [SerializeField] int _life;
    [Tooltip("ゲームマネージャー")]
    [SerializeField] GameManager _gm;
    [Tooltip("スタート地点")]
    [SerializeField] Transform _checkPoint;
    [Tooltip("ikeda/RespownCanvasのインスタンス")]
    [SerializeField] GameObject _whiteOut;
    [Tooltip("リスポーン時の待機時間")]
    [SerializeField] float _waitTime;
    [Tooltip("RespownCanvasのインスタンス下のテキスト")]
    [SerializeField] Text _text;

    private void Start()
    {
        transform.position = _checkPoint.position;
    }

    public void Damage()
    {
        _life--;
        if (!LifeCheck())
        {
            Respown();
        }

    }

    bool LifeCheck()
    {
        if (_life <= 0)
        {
            _gm.Death();
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
        {
            _checkPoint = collision.transform;
        }
        else if(collision.tag == "Goal")
        {
            _gm.Goal();
        }
    }
    public void Respown()
    {
        transform.position = _checkPoint.position;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _whiteOut.SetActive(true);
        _text.text = $"Life {_life}";
        StartCoroutine(RespownStay());
    }

    IEnumerator RespownStay()
    {
        yield return new WaitForSeconds(_waitTime);
        _whiteOut.SetActive(false);
        _gm.Resume();
    }
}
