using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateOpen : MonoBehaviour
{
    GameObject[] gates;
    GameObject gateLock;

	// Use this for initialization
	void Start () {
        gates = GameObject.FindGameObjectsWithTag("Gate");
        gateLock = GameObject.FindGameObjectWithTag("Lock");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickUpKey")
        {
            // other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            for(int i = 0; i < gates.Length; ++i)
            {
                GameObject gate = gates[i];
                if(0 == i)
                {
                    gate.transform.Rotate(0f, 90, 0f);
                }
                else
                {
                    gate.transform.Rotate(0f, -90, 0f);
                }
            }
            gateLock.gameObject.SetActive(false);
        }
    }
}
