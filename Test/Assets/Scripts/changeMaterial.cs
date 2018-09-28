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
	
	public void RenderHighlight()
    {
        if (rend != null)
        {
            rend.material = m_Material2;
           // Invoke("RevertHighlight", 0.1f);
        }
        else
        {
            Debug.Log("Can't render material");
        }
    }

    public void RevertHighlight()
    {
        if (rend != null)
        {
            rend.material = m_Material1;
        }
    }
}
