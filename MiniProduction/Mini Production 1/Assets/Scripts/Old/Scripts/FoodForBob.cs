using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodForBob : MonoBehaviour
{
    public int HungerReductionAmount = 30;

    private TimerTillFree timer;
    
    void Start ()
    {
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        if (timerObject != null)
        {
            timer = timerObject.GetComponent<TimerTillFree>();
        }
        else
        {
            Debug.Log("FoodForBob Can't find TimerObject");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bob")
        {
            if (timer != null)
            {
                timer.IncreaseHungerTimeFood(HungerReductionAmount);
            }
            Destroy(gameObject);
        }
    }
}
