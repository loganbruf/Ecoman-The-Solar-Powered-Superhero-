using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables
{
    public static int Lives { get; set; } = 3;
    public static int CurrLives { get; set; } = Lives;

    public static void ResetLives()
    {
        CurrLives = Lives;
    }
    
}
