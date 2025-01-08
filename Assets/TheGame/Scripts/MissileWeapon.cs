using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWeapon : Weapon
{

    [SerializeField] 
    GameObject _missilePrefab;

    override protected void Shoot(bool foundTarget, RaycastHit hitInfo, Vector3 direction)
    { 
      GameObject m = Instantiate(_missilePrefab, _muzzle.position, _muzzle.rotation) as GameObject; 
      m.transform.forward = direction; 
    }

    // Start is called before the first frame update
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

        if (Input.GetButtonDown("Fire1"))
        {
            Screen.lockCursor = true;
            Ray mouseRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            Vector3 direction;
            
          if (Physics.Raycast(mouseRay, out hitInfo))
          {
                direction = hitInfo.point - _muzzle.position;
                direction.Normalize();
          }
           else
           {
              direction = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 50)) - _muzzle.position;
              direction.Normalize();
           }
       
           GameObject m = Instantiate(_missilePrefab, _muzzle.position, _muzzle.rotation) as GameObject;
            m.transform.forward = direction;
        }
    }
}
