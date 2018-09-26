using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockManager : MonoBehaviour {

    public enum ELocks
    {
        YellowLock,
        BlueLock,
        GreenLock,
        IDSwipe
    }

    public ELocks lockType;

    public Text m_PlayerSpeech;
    private bool m_Closed;

    private void Start()
    {
        m_Closed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Player" == other.tag)
        {
            if (m_Closed)
            {
                m_PlayerSpeech.text = "I Need a KeyCard";
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

    private void OnDestroy()
    {
        //m_PlayerSpeech.text = "";
    }
}
