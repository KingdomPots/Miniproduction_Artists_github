 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour {

    public Text m_PlayerSpeech;

    private bool m_Closed;

	// Use this for initialization
	void Start ()
    {
        m_Closed = true;
        m_PlayerSpeech.text = "";
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter(Collider other)
    {
        if("Player" == other.tag)
        {
            if (m_Closed)
            {
                m_PlayerSpeech.text = "I Need a Key";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ("Player" == other.tag)
        {
            m_PlayerSpeech.text = "";
        }
    }

    public void OpenGate()
    {
        m_Closed = false;
        m_PlayerSpeech.text = "";
        //Destroy(GameObject.FindGameObjectWithTag("LockForGate").gameObject);
    }
}
