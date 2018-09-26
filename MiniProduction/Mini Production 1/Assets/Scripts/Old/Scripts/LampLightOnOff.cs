using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLightOnOff : MonoBehaviour
{
    Light myLight;
    bool lightOn;
    bool inRange;

	// Use this for initialization
	private void Start () {
        myLight = GetComponent<Light>();
        lightOn = true;
        inRange = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && inRange)
        {
            if (lightOn)
            {
                myLight.enabled = false;
                lightOn = false;
            }
            else
            {
                myLight.enabled = true;
                lightOn = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
}
