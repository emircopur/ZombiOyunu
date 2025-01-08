using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] 
    float _speed = 50.0f;

    [SerializeField] 
    int _damageDealt = 100;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, _speed), ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.transform.root.tag == "Player")
        {
            return;
        }

        Health h = c.transform.root.GetComponent<Health>();
         if (h != null)
         {
           h.Damage(_damageDealt);
         }

        Destroy(gameObject); 
    }
    void Update()
    {
        
    }
}
