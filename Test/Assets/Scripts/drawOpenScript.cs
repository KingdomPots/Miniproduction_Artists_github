using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawOpenScript : MonoBehaviour
{
    public float drawOpenDistance = 0.25f;

    private bool drawOpen;
    private bool canOpenDraw;

	// Use this for initialization
	void Start ()
    {
        drawOpen = false;
        canOpenDraw = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpenDraw && Input.GetKeyDown("space"))
        {
            if (drawOpen)
            {
                transform.Translate(Vector3.forward * drawOpenDistance);
                drawOpen = false;
            }
            else
            {
                transform.Translate(Vector3.forward * -drawOpenDistance);
                drawOpen = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canOpenDraw = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpenDraw = false;
        }
    }
}
