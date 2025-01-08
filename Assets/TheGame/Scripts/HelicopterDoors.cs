using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterDoors : MonoBehaviour
{

    void OnTriggerEnter(Collider c)
    {

        if (c.transform.root.tag == "Player")
            
        {
            GameManager.WinPlayer();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
