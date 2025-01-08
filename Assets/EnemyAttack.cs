using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

     float _nextTimeAttackIsAllowed = -1.0f;

    [SerializeField] 
    float _attackDelay = 1.0f; 
 
    [SerializeField] 
     int _damageDealt = 5;

    [SerializeField] 
    GameObject _hitEffectPrefab;

    void OnTriggerStay(Collider other)
     
    { 
         
    if (other.tag == "Player" && Time.time >= _nextTimeAttackIsAllowed)

        {

         Health playerHealth = other.GetComponent<Health>();
         playerHealth.Damage(_damageDealt);

           Vector3 hitDirection = (transform.root.position - other.transform.position).normalized;
           Vector3 hitEffectPosition = other.transform.position + (hitDirection * 0.01f) + (Vector3.up * 1.5f);
           Quaternion hitEffectRotation = Quaternion.FromToRotation(Vector3.forward, hitDirection);
           Instantiate(_hitEffectPrefab, hitEffectPosition, hitEffectRotation);

            _nextTimeAttackIsAllowed = Time.time + _attackDelay;
        }

} 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
