﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{

    [SerializeField] int _life;
    [SerializeField] GameManager _gm;
    [SerializeField] Transform _checkPoint;

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
    }
    public void Respown()
    {
        transform.position = _checkPoint.position;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}