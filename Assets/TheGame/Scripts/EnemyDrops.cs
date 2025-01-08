using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    [SerializeField] 
    GameObject _dropItemPrefab;

    [SerializeField] 
    float _chanceToDrop = 50.0f;

    public void OnDeath()
    {
        if (Random.Range(0.0f, 100.0f) <= _chanceToDrop)
        {
            Instantiate(_dropItemPrefab, transform.position, transform.rotation);
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
