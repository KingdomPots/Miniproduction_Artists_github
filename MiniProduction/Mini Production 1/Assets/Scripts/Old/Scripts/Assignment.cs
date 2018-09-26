using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment : MonoBehaviour {

    public GameObject assignmentUI;

    // Use this for initialization
    void Start () {
        GameManager.SetAssignmentOpen(true);
        assignmentUI.SetActive(true);
    }

    public void CloseAssignment()
    {
        GameManager.SetAssignmentOpen(false);
        assignmentUI.SetActive(false);
    }
}
