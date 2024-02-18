using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class BlobEnemy : Enemy
{
    [SerializeField] private LayerMask platformLayerMask;
    public float xSpeed;
    public float ySpeed;
    public float phaseTime;
    private int _phase = 0;
    private float _phaseTimer;
    private float _startingY;
    private CapsuleCollider2D _capsuleCollider2D;
    private bool _isJumping;
    
    private void Start()
    {
        _startingY = rb.position.y;
        _capsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();
        _phaseTimer = phaseTime;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        _phaseTimer -= Time.deltaTime;
        
        if (_phaseTimer <= 0)
        {
            _phase = _phase == 0 ? 1 : 0;
            if (_phase == 0)
            {
                rb.velocity = new Vector2(xSpeed, ySpeed);
            }
            else
            {
                rb.velocity = new Vector2(-xSpeed, ySpeed);
            }

            _phaseTimer = phaseTime;
        }
    }
    
}
