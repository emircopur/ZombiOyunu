using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class RifleWeapon : Weapon
{

   [SerializeField] 
   int _damageDealt = 10;

   [SerializeField] 
   GameObject _hitEffectPrefab;

    override protected void Shoot(bool foundTarget, RaycastHit hitInfo, Vector3 direction)
     { 
         if (!foundTarget) 
         { 
             return; 
         } 
  
         Health enemyHealth = hitInfo.transform.GetComponent<Health>(); 
         if (enemyHealth != null) 
         { 
             enemyHealth.Damage(_damageDealt); 
  
             Vector3 hitEffectPosition = hitInfo.point; 
             Quaternion hitEffectRotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal); 
             Instantiate(_hitEffectPrefab, hitEffectPosition, hitEffectRotation); 
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
