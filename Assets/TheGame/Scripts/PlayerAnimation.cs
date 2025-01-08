using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _anim;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                _anim.SetFloat("Horizontal", h);
                _anim.SetFloat("Vertical", v);
       
         if (!Mathf.Approximately(h, 0f) || !Mathf.Approximately(v, 0f))
           _anim.SetBool("Motion", true);
                else
           _anim.SetBool("Motion", false);
    }
}
