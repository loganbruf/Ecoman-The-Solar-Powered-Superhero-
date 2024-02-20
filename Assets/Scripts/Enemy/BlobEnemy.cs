using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class BlobEnemy : Enemy.Enemy
{
    public float xSpeed;
    public float ySpeed;
    public float phaseTime;
    private int _phase = 0;
    private float _phaseTimer;
    private bool _isJumping;
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _phaseTimer = phaseTime;
        spawnPoint = transform.position;
    }

    void Update()
    {
        DestroyOnZeroHealth();
        _phaseTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (_phaseTimer <= 0)
        {
            _phase = _phase == 0 ? 1 : 0;
            if (_phase == 0)
            {
                _rb.velocity = new Vector2(xSpeed, ySpeed);
            }
            else
            {
                _rb.velocity = new Vector2(-xSpeed, ySpeed);
            }
            _phaseTimer = phaseTime;
        }
    }
}
