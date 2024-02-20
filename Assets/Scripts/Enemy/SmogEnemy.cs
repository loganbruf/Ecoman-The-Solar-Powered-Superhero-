using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogEnemy : Enemy.Enemy
{
    public float amplitude = 1f; // The height of the wave
    public float frequency = 1f; // The speed of the wave
    public float speedX;
    public float phaseTime;
    
    private float _startTime;
    private int _phase;
    private float _timer;
    private float _startingY;
   
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _timer = phaseTime;
        _phase = 1;
        _startingY = transform.position.y;
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOnZeroHealth();
        
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _phase = _phase == -1 ? 1 : -1;
            _timer = phaseTime;
        }
        // Calculate the sine wave offset
        float waveOffsetY = Mathf.Sin((Time.time - _startTime) * frequency);

        // Apply the offset to the Y position of the GameObject
        Vector3 newPosition = transform.position;
        newPosition.y = _startingY + waveOffsetY * amplitude;
        newPosition.x += speedX * _phase;
        
        transform.position = newPosition;
    }
    
}
