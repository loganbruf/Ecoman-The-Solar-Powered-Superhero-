using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int lives;
    public int hearts;
    public Transform spawnpoint;
    public GameObject player;
    [NonSerialized] public int CurrLives;
    [NonSerialized] public int CurrHearts;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public void Awake()
    {
        // Check if there's already an instance of this class. If yes, destroy this one. If not, set this as the instance.
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        CurrHearts = hearts;
        CurrLives = lives;
    }

    private void Update()
    {
        if (CurrHearts <= 0)
        {
            LoseLife();
        }
    }

    public void Respawn()
    {
        player.transform.position = spawnpoint.position;
    }

    public void LoseLife()
    {
        CurrLives--;
        CurrHearts = hearts;
        Respawn();
    }
    
}
