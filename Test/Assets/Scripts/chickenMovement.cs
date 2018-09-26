using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenMovement : MonoBehaviour
{
    Transform player;
    Transform Bob;
    UnityEngine.AI.NavMeshAgent nav;
    public float range = 5f;
    public float multiplier = 2f;
    public float distanceFromBob = 2f;
    private Animator anim;

    private TimerTillFree timer;
    private bool inBobRadius;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Bob = GameObject.FindGameObjectWithTag("Bob").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        if (timerObject != null)
        {
            timer = timerObject.GetComponent<TimerTillFree>();
        }
        else
        {
            Debug.Log("ChickenMovement Can't find TimerObject");
        }

        inBobRadius = false;

        anim = transform.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector3 runTo = transform.position + ((transform.position - player.position) * multiplier);
        float distancePlayer = Vector3.Distance(player.position, transform.position);
        float distanceBob = Vector3.Distance(Bob.position, transform.position);
        
        if (inBobRadius)
        {
            if (distanceBob < distanceFromBob)
            {
                //Play Monster eating chicken sound
                if (timer != null)
                {
                    timer.IncreaseHungerTimeChicken();
                }
                Destroy(gameObject);
            }
            else
            {
                nav.SetDestination(Bob.position);
            }
        }
        else if (distancePlayer < range)
        {
            nav.SetDestination(runTo);
        }

        Vector3 test = new Vector3(0.0f, 0.0f, 0.0f);

        if (nav.velocity != test)
        {
            if(anim != null)
                anim.SetBool("isMoving", true);
        }
        else
        {
            if (anim != null)
                anim.SetBool("isMoving", false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bob")
        {
            inBobRadius = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bob")
        {
            inBobRadius = false;
        }
    }
}


