using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives;
    public int hearts;
    public Transform spawnpoint;
    public GameObject player;
    [NonSerialized] public int CurrHearts;
    
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

        CurrHearts = hearts;
        GameVariables.Lives = lives;
        if (GameVariables.CurrLives < 0)
        {
            GameVariables.CurrLives = GameVariables.Lives;
        }
    }

    private void Start()
    {
        _wompwomp = GetComponent<AudioSource>();
        _soundPlaying = false;
    }

    void Update()
    {
        if (CurrHearts <= 0 && !_soundPlaying)
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

    public void LoseLife()
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
    
}
