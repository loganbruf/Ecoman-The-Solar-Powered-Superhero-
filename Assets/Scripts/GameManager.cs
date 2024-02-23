using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int hearts;
    public Transform spawnpoint;
    public GameObject player;
    
    private int _currHearts;
    private static GameManager _instance;
    private Queue<Enemy.Enemy> _disabledEnemies = new Queue<Enemy.Enemy>();
    private AudioSource _wompwomp;
    private bool _soundPlaying;
    

    public static GameManager Instance
    {
        get { return _instance; }
    }

    void Awake()
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

        _currHearts = hearts;
        if (GameVariables.CurrLives < 0)
        {
            GameVariables.ResetLives();
        }
    }

    private void Start()
    {
        _wompwomp = GetComponent<AudioSource>();
        _soundPlaying = false;
    }

    void Update()
    {
        if (_currHearts <= 0 && !_soundPlaying)
        {
            _wompwomp.Play();
            _soundPlaying = true;
            StartCoroutine(WaitForSoundAndThenDie());
        }
    }
    
    public void Respawn()
    {
        player.transform.position = spawnpoint.position;
    }

    private void LoseLife()
    {
        GameVariables.CurrLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator WaitForSoundAndThenDie()
    {
        
        while (_wompwomp.isPlaying)
        {
            Time.timeScale = 0;
            yield return null;
        }

        _soundPlaying = false;
        Time.timeScale = 1;
        LoseLife();
    }

    public void ChangeHealth(int health)
    {
        int healthIn = _currHearts + health;
        if (healthIn > hearts)
        {
            healthIn = hearts;
        }

        _currHearts = healthIn;
    }

    public void SetHealth(int health)
    {
        int healthIn = health;
        if (healthIn > hearts)
        {
            healthIn = hearts;
        }

        _currHearts = healthIn;
    }

    public int GetHearts()
    {
        return _currHearts;
    }
    
}
