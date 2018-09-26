using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    public GameObject pauseMenuUI;
    public GameObject backpackUI;
    public GameObject controlsUI;
    private bool m_isInControls = false;

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.IsGamePaused())
            {
                if (!m_isInControls)
                    Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameManager.SetGamePaused(false);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameManager.SetGamePaused(true);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("MenuScreen");
    }

    public void LoadControls()
    {
        Debug.Log("Loading Backpack");
        controlsUI.SetActive(true);
        m_isInControls = true;
        //GameManager.SetInInventory(true);
    }

    public void CloseControls()
    {
        Debug.Log("Loading Backpack");
        controlsUI.SetActive(false);
        m_isInControls = false;
        //GameManager.SetInInventory(true);
    }

    public void CloseBackpack()
    {
        backpackUI.SetActive(false);
        GameManager.SetInInventory(false);
        Debug.Log("Closing Backpack");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
