using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] 
     float _secondsToLand = 180.0f;
    void Start()
    {
        GetComponent<Animation>()["Flying"].wrapMode = WrapMode.Loop;

        GetComponent<Animation>()["Landed"].wrapMode = WrapMode.ClampForever;

        GetComponent<Animation>()["Landing"].wrapMode = WrapMode.ClampForever;

        GetComponent < Animation >().Blend("Landing", 1.0f, 0.01f);

        GetComponent<Animation>().Blend("Flying", 1.0f, 0.01f);

        GetComponent<Animation>()["Landing"].speed = 0;

        Invoke("Land", _secondsToLand);
    }

    public void Land()
    {
        GetComponent<Animation>()["Landing"].speed = 1;
    }
    void Update()
    {
        if (GetComponent<Animation>()["Landing"].normalizedTime >= 1.0f)
        {
            GetComponent<Animation>().Blend("Landed", 1.0f, 0.01f);
        }

    }
}
