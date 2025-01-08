using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookx : MonoBehaviour
{

        [SerializeField] 
        float _sensitivity = 5.0f;

        float _mouseX = 0.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            _mouseX = Input.GetAxis("Mouse X");

            Vector3 rot = transform.localEulerAngles;
            rot.y += _mouseX * _sensitivity;
            transform.localEulerAngles = rot;
        }
    }