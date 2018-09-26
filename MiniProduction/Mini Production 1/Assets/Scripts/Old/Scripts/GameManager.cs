using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    static private bool m_gameIsPaused = false;
    static private bool m_inInventory = false;
    static private bool m_inMainMenu = false;
    static private bool m_stopTime = false;
    static private bool m_bEscaped = false;
    static private bool m_LoadedFinalLevel = false;
    static private bool m_noteOpen = false;
    static private bool m_assignmentOpen = true;
    static private bool m_isEnding = false;

    static private int m_NotesCollected;
    static private int m_iTotalNotes;
    //static public InventorySlot[] storedSlots;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        m_NotesCollected = 0;
        m_iTotalNotes = 12;
    }

    void Update()
    {
        //Time pause code
        if(m_gameIsPaused || m_inInventory || m_assignmentOpen)
        {
            Time.timeScale = 0.0f;
            m_stopTime = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            m_stopTime = false;
        }

        //Ending game code
        if(SceneManager.GetActiveScene().name == "MenuScreen")
        {
            ResetMainMenu();
            m_NotesCollected = 0;
        }
        else if(SceneManager.GetActiveScene().name == "Main")
        {
            m_inMainMenu = false;
            m_LoadedFinalLevel = false;
        }
        else if(SceneManager.GetActiveScene().name == "EndScreen")
        {
            GameObject EndingDecider = GameObject.FindGameObjectWithTag("EndingChooser");
            if (null != EndingDecider)
            {
                if (!m_LoadedFinalLevel)
                {
                    //Debug.Log("Found EndDecider");
                    Ending endScript = EndingDecider.GetComponent<Ending>();

                    //Load ending equivilant to user score
                    if (!m_bEscaped)
                    {
                        //Didn't escape
                        endScript.LevelToLoad(0);
                        Debug.Log("Player died");
                    }
                    else
                    {
                        //Escaped, now decide which Escape Level to load depending on notes collected
                        float fNotesCollectedPercentage = ((float)m_NotesCollected / (float)m_iTotalNotes);


                        Debug.Log("Percentage " + fNotesCollectedPercentage);

                        //C - 0-5 notes
                        if (fNotesCollectedPercentage < 0.5f)
                        {
                            endScript.LevelToLoad(1);
                        }
                        //B - 6-9 notes
                        else if (fNotesCollectedPercentage < 0.8f)
                        {
                            endScript.LevelToLoad(2);
                        }
                        //A - 10-11 notes
                        else if (fNotesCollectedPercentage < 0.9999f)
                        {
                            endScript.LevelToLoad(3);
                        }
                        //S - 12 notes
                        else
                        {
                            endScript.LevelToLoad(4);
                        }

                        //endScript.LevelToLoad(1);

                        Debug.Log("Player escaped");
                    }
                    m_LoadedFinalLevel = true;
                    m_NotesCollected = 0;
                }
            }
            else
            {
                Debug.Log("Didn't find EndDecider");
            }
        }
    }
    
    static public GameManager GetInstance()
    {
        return instance;
    }

    static public void ResetMainMenu()
    {
        m_inMainMenu = true;
        m_LoadedFinalLevel = false;
        m_gameIsPaused = false;
        m_inInventory = false;
        m_stopTime = false;
        m_noteOpen = false;
        m_isEnding = false;
    }

    static public void SetGamePaused(bool paused)
    {
        if(!m_inInventory)
        {
            m_gameIsPaused = paused;
        }
    }

    static public bool IsGamePaused()
    {
        return m_gameIsPaused;
    }

    static public void SetInInventory(bool accessed)
    {
        m_inInventory = accessed;
    }

    static public bool GetInInventory()
    {
        return m_inInventory;
    }
    static public void SetInMenu(bool accessed)
    {
        m_inMainMenu = accessed;
    }

    static public bool GetInMenu()
    {
        return m_inMainMenu;
    }

    static public void SetNoteOpen(bool accessed)
    {
        m_noteOpen = accessed;
    }

    static public bool GetNoteOpen()
    {
        return m_noteOpen;
    }

    static public void SetAssignmentOpen(bool accessed)
    {
        m_assignmentOpen = accessed;
    }

    static public bool GetAssignmentOpen()
    {
        return m_assignmentOpen;
    }

    static public bool GetIsTimeStopped()
    {
        return m_stopTime;
    }

    static public void GameOver(bool _bEscaped)
    {
        m_bEscaped = _bEscaped;
        m_isEnding = true;
        SceneManager.LoadScene("EndScreen");
    }

    static public bool GetIsEnd()
    {
        return m_isEnding;
    }

    static public void IncreaseNotes()
    {
        m_NotesCollected += 1;
    }

    static public int GetNoteCount()
    {
        return (m_NotesCollected);
    }
    static public int GetTotalNotes()
    {
        return (m_iTotalNotes);
    }
}
