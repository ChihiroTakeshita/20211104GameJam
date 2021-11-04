﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _pSprite;
    [SerializeField] float _moveSpeed = 1f;

    Rigidbody2D _rb;
    Vector3 _defaultScale;
    bool _isFlip;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _defaultScale = _pSprite.transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var velocityY = _rb.velocity.y;
        if(_isFlip && h > 0)
        {
            _pSprite.transform.localScale = _defaultScale;
            _isFlip = !_isFlip;
        }
        else if(!_isFlip && h < 0)
        {
            _pSprite.transform.localScale = new Vector3(_defaultScale.x * -1, _defaultScale.y, _defaultScale.z);
            _isFlip = !_isFlip;
        }
        _rb.velocity = new Vector3(h * _moveSpeed, velocityY, 0);
    }
}