using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectsCleanup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
           child.parent = null;
        }
       Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
