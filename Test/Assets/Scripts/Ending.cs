using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject[] EndingLevels;
    public Sprite test;
    public Sprite[] GradeImages;
    public Text notesScore;
    public GameObject Note;
    //public GameObject inventoryUI;

    private int EndingLevelToLoad;
    private Image grade;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < EndingLevels.Length; ++i)
        {
            EndingLevels[i].SetActive(false);
        }

        GameObject canvasObject = GameObject.FindGameObjectWithTag("EatenEnd");
        if(null != canvasObject)
        {
            grade = canvasObject.GetComponent<Image>();
            if(null == grade)
            {
               Debug.Log("Can't find Grade image");
            }
        }
        else
        {
            Debug.Log("Can't find canvasObject");
        }

        EndingLevelToLoad = 0;

        notesScore.text = "";
    }

    public void LevelToLoad(int i)
    {
        EndingLevelToLoad = i;// (int)Mathf.Clamp(EndingLevelToLoad, 0, EndingLevels.Length + 1);
        
        if (null == grade)
        {
            Debug.Log("Can't find Grade image");
        }
        else
        {
            Debug.Log("Found Grade image");
            /*  It will go into above if and this... Ummm. Why? 
                It's working at the moment... So I'll leave it
            */
            switch (EndingLevelToLoad)
            {
                case 0:
                    {
                        grade.sprite = GradeImages[0];
                        EndingLevels[0].SetActive(true);
                        break;
                    }
                case 1:
                    {
                        grade.sprite = GradeImages[1];
                        EndingLevels[1].SetActive(true);
                        break;
                    }
                case 2:
                    {
                        grade.sprite = GradeImages[2];
                        EndingLevels[1].SetActive(true);
                        break;
                    }
                case 3:
                    {
                        grade.sprite = GradeImages[3];
                        EndingLevels[1].SetActive(true);
                        break;
                    }
                case 4:
                    {
                        grade.sprite = GradeImages[4];
                        EndingLevels[1].SetActive(true);
                        break;
                    }
            }
        }

        notesScore.text = GameManager.GetNoteCount().ToString() + "/" + GameManager.GetTotalNotes().ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.ResetMainMenu();
            SceneManager.LoadScene("MenuScreen");
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
        //else if (Input.GetButtonDown("Inventory"))
        //{
        //    if (!inventoryUI.activeSelf)
        //    {
        //        inventoryUI.SetActive(true);
        //        GameManager.SetInInventory(true);
        //        Debug.Log("Loading Backpack");
        //    }
        //    else
        //    {
        //        inventoryUI.SetActive(false);
        //        GameManager.SetInInventory(false);
        //        Debug.Log("Closing Backpack");
        //    }
        //}
    }
}
