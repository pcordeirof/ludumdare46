using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject restartMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("PlayerController").GetComponent<PlayerController>().lifesScore > 0)
        {
             if (Input.GetKeyDown(KeyCode.Escape))
             {
                if(GameIsPaused)
                {
                    Resume();
                } else 
                {
                    Pause();
                }
            }
        }
        else
        {
            youLose();
        }     
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().ChangeVolume(GameIsPaused);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true; 
        GameObject.Find("AudioManager").GetComponent<AudioManager>().ChangeVolume(GameIsPaused); 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().playAll();
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void youLose()
    {
        restartMenuUI.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void Restart()
    {
        restartMenuUI.SetActive(false);
        SceneManager.LoadScene(2);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().playAll();
        Time.timeScale = 1f;
    }

}
