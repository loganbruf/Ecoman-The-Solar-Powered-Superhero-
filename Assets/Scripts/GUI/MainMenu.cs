using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstSceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(firstSceneName);
        GameVariables.ResetLives();
    }
}
