using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] 
    protected Transform _muzzle;

    [SerializeField] 
     float _fireDelay = 0.3f; 

     float _nextFireTimeAllowed = -1.0f;

    void Start()
    {
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Screen.lockCursor = false;
        }

        if (Input.GetButton("Fire1") && Time.time >= _nextFireTimeAllowed)
        {
            _nextFireTimeAllowed = Time.time + _fireDelay;

            Screen.lockCursor = true;
            Ray mouseRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            Vector3 direction;
            bool foundTarget = false;

            if (Physics.Raycast(mouseRay, out hitInfo) && (Camera.main.WorldToScreenPoint(hitInfo.point).z >= Camera.main.WorldToScreenPoint(_muzzle.position).z))
            {
                foundTarget = true;
                direction = hitInfo.point - _muzzle.position;
                direction.Normalize();
            }
            else
            {
                direction = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 50)) - _muzzle.position;
                direction.Normalize();
            }

            RaycastHit gunHitInfo;
            if (Physics.Raycast(_muzzle.position, direction, out gunHitInfo))
            {
              foundTarget = true;
            }

            Shoot(foundTarget, gunHitInfo, direction);
        }
    }
    virtual protected void Shoot(bool foundTarget, RaycastHit hitInfo, Vector3 direction)
    { 
    }
}
