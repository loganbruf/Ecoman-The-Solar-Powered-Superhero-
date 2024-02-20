using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDActions : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = GameVariables.CurrLives.ToString();
        }
        
    }
}
