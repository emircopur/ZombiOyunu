using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static bool _hasPlayerWon = false;

    public static bool HasPlayerWon { get { return _hasPlayerWon; } }

    public static void WinPlayer()
    {
        _hasPlayerWon = true;
    }


    void Start()
    {
        
    }

    void CheckWin()
    {
        

    }

// Update is called once per frame
void Update()
    {
        
    }
}
