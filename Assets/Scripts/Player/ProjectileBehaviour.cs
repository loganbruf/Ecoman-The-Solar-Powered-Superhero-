using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed;
    public int directionX;
    public int directionY;
    public float timeToDestroy;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(speed * directionX, speed * directionY);
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy.Enemy>();
        if (enemy == null) return;
        enemy.health--;
        var sound = other.GetComponent<AudioSource>();
        if (sound != null && !sound.isPlaying)
        {
            sound.Play();
        }
        Destroy(gameObject);
    }
}
