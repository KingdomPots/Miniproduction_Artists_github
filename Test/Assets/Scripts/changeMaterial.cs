using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterial : MonoBehaviour
{
    public Material m_Material1;
    public Material m_Material2;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponentInChildren<Renderer>();
    }
	
	private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (rend != null)
            {
                rend.material = m_Material2;
            }
            else
            {
                Debug.Log("Can't render material");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (rend != null)
            {
                rend.material = m_Material1;
            }
        }
    }
}
