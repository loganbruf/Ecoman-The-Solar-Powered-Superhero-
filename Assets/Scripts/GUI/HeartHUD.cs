using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHUD : MonoBehaviour
{

    private Image[] _hearts;
    
    // Start is called before the first frame update
    void Start()
    {
        _hearts = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (GameManager.Instance.GetHearts() >= i + 1)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }
}
