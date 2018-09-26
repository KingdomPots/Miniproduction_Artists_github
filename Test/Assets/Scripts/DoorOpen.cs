using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float doorOpenAngle = 155f;
    public float smooth = 2.0f;
    private int doorCoolDown = 20;

    private bool doorOpen;
    private bool canOpenDoor;
    private float doorCountDown;

    void Start()
    {
        doorOpen = false;
        canOpenDoor = false;
        doorCountDown = Time.time + 10000000000f;


        transform.Rotate(0f, 0f, 0f);
    }

    void Update()
    {
        if(canOpenDoor && Input.GetKeyDown("space"))
        {
            if(doorOpen)
            {
                //Play Door closed sound
                transform.Rotate(0f, -doorOpenAngle, 0f);
                doorOpen = false;
            }
            else
            {
                //Play Door open sound
                transform.Rotate(0f, doorOpenAngle, 0f);
                doorCountDown = Time.time + (float)doorCoolDown;
                doorOpen = true;
            }
        }

        if(Time.time > doorCountDown)
        {
            //Play Door closed sound
            transform.Rotate(0f, -doorOpenAngle, 0f);
            doorOpen = false;
            doorCountDown = Time.time + 10000000000f;
        }
    }

    void OnTriggerEnter()
    {
        canOpenDoor = true;
    }

    void OnTriggerExit()
    {
        canOpenDoor = false;
    }
}
