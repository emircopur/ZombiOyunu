using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] 
    int _healAmount = 50;
    void OnTriggerEnter(Collider c)
    { 
       if (c.transform.root.tag == "Player") 
       {
            Health playerHealth = c.transform.root.GetComponent<Health>();
            playerHealth.Heal(_healAmount);
            Destroy(gameObject);
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
