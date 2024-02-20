using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour
{

    public float timer; //How often will player take damage when in shadow?
    private float _currTime;

    private void Start()
    {
        _currTime = timer;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerActions>();
        if (player == null) return;
        _currTime -= Time.deltaTime;
        if (!(_currTime <= 0)) return;
        player.TakeDamage(1);
        _currTime = timer;
    }
}
