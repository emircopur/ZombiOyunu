using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGui : MonoBehaviour
{


    [SerializeField] 
    Texture2D _crosshair; 

        void OnGUI()
     {
        GUI.Label(new Rect(5, 5, 100, 100), "Health: " + _playerHealth);

        float x = (Screen.width - _crosshair.width) / 2;
        float y = (Screen.height - _crosshair.height) / 2;
        GUI.DrawTexture(new Rect(x, y, _crosshair.width, _crosshair.height), _crosshair);
     }

    // Start is called before the first frame update

    Health _playerHealth;
    void Start()
    {
        _playerHealth = GetComponent<Health>();
    }

         // Update is called once per frame
        void Update()
    {
        
    }
}
