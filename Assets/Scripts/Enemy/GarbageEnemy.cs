using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEnemy : Enemy.Enemy
{
    public Transform point1;
    public Transform point2;
    public float speed;
    private int _phase = 0;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOnZeroHealth();
        
        if (_phase == 0)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, point1.position, step);
            if (Vector2.Distance(transform.position, point1.position) < 0.1f)
            {
                _phase = 1;
            }
        }
        else
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, point2.position, step);
            if (Vector2.Distance(transform.position, point2.position) < 0.1f)
            {
                _phase = 0;
            }
        }
    }
    
}
