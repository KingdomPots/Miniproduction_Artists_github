using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if(null == player)
        {
            Debug.Log("LookAtPlayer can't find player");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(player.transform);
	}
}
