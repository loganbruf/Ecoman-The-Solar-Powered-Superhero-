using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    public AudioSource mainMusic;
    public GameObject WinScreen;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerActions>() == null) return;
        mainMusic.Stop();
        gameObject.GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
        WinScreen.SetActive(true);
    }
}
