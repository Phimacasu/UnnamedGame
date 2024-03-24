using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private static bool _gamePaused = false;
    public static bool IsGamePaused()
    {
        return _gamePaused;
    }

    public GameObject _pauseGame;

    [SerializeField]
    private KeyCode _pauseKey = KeyCode.Escape;

    [SerializeField]
    private string _exitSceneName = "OtherStart";

    void Update()
    {
        if (Input.GetKeyDown(_pauseKey))
        {
            if (_gamePaused)
            {
                ResumeGame();
            }
            else
            {
                Paused();
            }
        }
        Time.timeScale = !_gamePaused ? 1f : 0f;
    }

    public void ResumeGame()
    {
        _pauseGame.SetActive(false);
        _gamePaused = false;
    }

    void Paused()
    {
        _pauseGame.SetActive(true);
        _gamePaused = true;
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_exitSceneName);
        Debug.LogFormat("Exit Game: {0}", SceneManager.GetActiveScene().name);
    }
}
