using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manniquin : MonoBehaviour {

    public Vector2 teleportMaxMin = new Vector2(1f, 20f);

    GameObject player;

    float timeToJump;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (null == player)
        {
            Debug.Log("LookAtPlayer can't find player");
        }
        timeToJump = 999999999f;
    }

    // Update is called once per frame
    void Update ()
    {
        if(!gameObject.GetComponentInChildren<Renderer>().isVisible)
        {
            if(timeToJump < Time.time)
            {
                transform.transform.position = player.transform.position - player.transform.forward * 0.75f - player.transform.up * 1.0f;
                timeToJump = Time.time + Random.Range(teleportMaxMin.x, teleportMaxMin.y);
            }
            Debug.Log("NotVisible");
            Vector3 LookatMe = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(LookatMe);

        }
    }

    public void GameStart()
    {
        timeToJump = Time.time + Random.Range(teleportMaxMin.x, teleportMaxMin.y);
    }
}
