using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sun : MonoBehaviour
{
    public abstract void ApplyEffect(PlayerActions player);
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerActions player = other.gameObject.GetComponent<PlayerActions>();
        if(player == null) return;
        ApplyEffect(player);
        Destroy(gameObject);
    }
}
