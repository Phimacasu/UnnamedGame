using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pauseGame;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                Paused();
            }
        }
    }

    public void ResumeGame()
    {
        pauseGame.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Paused()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("OtherStart");
        Debug.Log("Exit Game");
    }
}
