using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looky : MonoBehaviour
{

    [SerializeField] 
     float _sensitivity = 5.0f; 
      
     float _mouseY = 0.0f;

    [SerializeField]
    private float _minRotation = -90.0f;  // Minimum rotation angle (e.g., look down limit)

    [SerializeField]
    private float _maxRotation = 90.0f;

    float _currentRotationX = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _currentRotationX = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseY = -Input.GetAxis("Mouse Y") * _sensitivity;

        _currentRotationX += _mouseY;

        _currentRotationX = Mathf.Clamp(_currentRotationX, _minRotation, _maxRotation);

        transform.localEulerAngles = new Vector3(_currentRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);

    }
}
