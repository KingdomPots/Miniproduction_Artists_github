using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour {

    [Header("Ray Properties")]
    public float m_fRayDistance = 3.0f;


    //[Header("Particles")]
    //public GameObject m_keyObtainedParticle;
    //public GameObject m_SpawnEachInteraction;
    ////public Image CanPickUp;

    //[Header("Audio")]
    //public AudioSource m_keyObtainedAudio;
    //public AudioSource m_unlockAudio;

    //Private
    private RaycastHit m_objectHit;
    private bool m_bSpacePressed = false;
    private bool m_bActionDone = false;

    private GameObject Player;
    private GameObject lastInteraction;

    // Use this for initialization
    void Start () {
        //m_keyObtainedAudio.Stop();
        //m_unlockAudio.Stop();
        Player = GameObject.FindGameObjectWithTag("Player");
        if(null == Player)
        {
            Debug.Log("Player not found");
        }
        lastInteraction = null;
    }
	
	// Update is called once per frame
	void Update () {

        

        Debug.DrawRay(this.transform.position, this.transform.forward * m_fRayDistance, Color.magenta);

        //Get raycast of object the player 
        if (Physics.Raycast(this.transform.position, this.transform.forward, out m_objectHit, m_fRayDistance))
        {
            Debug.Log(m_objectHit.collider.tag);

            if (m_objectHit.collider.tag.Contains("PickUp"))
            {
                if(lastInteraction != null)
                {
                    if(m_objectHit.collider.gameObject != lastInteraction)
                    {
                        if (null != lastInteraction.GetComponent<changeMaterial>())
                        {
                            lastInteraction.GetComponent<changeMaterial>().RevertHighlight();
                        }
                    }
                }
                m_objectHit.collider.GetComponent<changeMaterial>().RenderHighlight();
                lastInteraction = m_objectHit.collider.gameObject;
            }
            else
            {
                if (lastInteraction != null)
                {
                    if (null != lastInteraction.GetComponent<changeMaterial>())
                    {
                        lastInteraction.GetComponent<changeMaterial>().RevertHighlight();
                    }
                    lastInteraction = null;
                }
            }

            if (InputManager.GetAxisOnce(ref m_bSpacePressed, "Pickup"))
            {
                if (m_objectHit.collider.CompareTag("PickupNote"))
                {
                    m_objectHit.collider.GetComponent<ItemPickup>().Interact();
                }
                else if (m_objectHit.collider.tag.Contains("PickUp"))
                {
                    Player.GetComponent<PickUpScript>().HandleItemInteraction(m_objectHit.collider.gameObject);
                }

            }
        }
        else
        {
            if (lastInteraction != null)
            {
                if (null != lastInteraction.GetComponent<changeMaterial>())
                {
                    lastInteraction.GetComponent<changeMaterial>().RevertHighlight();
                }
                lastInteraction = null;
            }
        }
    }
}
