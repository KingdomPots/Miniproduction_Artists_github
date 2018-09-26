using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pickMeUpSpace : MonoBehaviour
{

    public TextMeshProUGUI pickMeUp;

    private void Start()
    {
        if(pickMeUp != null)
            pickMeUp.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && pickMeUp != null)
        {
            pickMeUp.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && pickMeUp != null)
        {
            pickMeUp.enabled = false;
        }
    }

    //void OnDestroy()
    //{
    //    if (pickMeUp != null)
    //    {
    //        pickMeUp.enabled = false;
    //        Destroy(pickMeUp.gameObject);
    //    }
    //}
}
