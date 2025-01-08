using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatGui : MonoBehaviour
{
    Health _playerHealth;
    PlayerStats _playerStats;

    [SerializeField] 
     Texture2D _gameOverImage;

    [SerializeField] 
   Texture2D _winImage;

    void Start()
    { 
         GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player"); 
        _playerHealth = playerGameObject.GetComponent<Health>();
        _playerStats = playerGameObject.GetComponent<PlayerStats>();
    }

    void OnGUI()
    {
         if (_playerHealth.IsDead)
         {
            float x = (Screen.width - _gameOverImage.width) / 2;
            float y = (Screen.height - _gameOverImage.height) / 2;
            GUI.DrawTexture(new Rect(0, 0, _gameOverImage.width, _gameOverImage.height),
            _gameOverImage);
            GUI.Label(new Rect(x + 100, y + 280, 100, 100), "Zombies killed: " + _playerStats.
            ZombiesKilled);
        }
        else if (GameManager.HasPlayerWon)
        {
            float x = (Screen.width - _winImage.width) / 2;
            float y = (Screen.height - _winImage.height) / 2;
            GUI.DrawTexture(new Rect(x, y, _winImage.width, _winImage.height), _winImage);
            GUI.Label(new Rect(x + 100, y + 280, 100, 100), "Zombies killed: " + _playerStats.
            ZombiesKilled);
        }

    }
void Update()
    {
        
    }
}
