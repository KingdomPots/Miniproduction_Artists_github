using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public float m_ChaseSpeed = 5.0f;
    public BoxCollider myCollider;

    private bool m_TargetPlayer = false;

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
        if (!m_TargetPlayer)
        {
            transform.LookAt(player.transform);
        }
        else
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * m_ChaseSpeed * Time.deltaTime);

            float distancePlayer = Vector3.Distance(player.transform.position, transform.position);

            if(3.0f > distancePlayer)
            {
                // Player face monster
                // Play crunch sound
                // Go to end screen
                GameManager.GameOver(false);
            }
        }
	}

    public void TargetPlayer()
    {
        m_TargetPlayer = true;
        myCollider.enabled = false;
    }
}
