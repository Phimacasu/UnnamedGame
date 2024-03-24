using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private const string _SampleSceneString = "SampleScene";
    private const string _SettingsMenuString = "SettingsMenu";
    private const string _MainMenuString = "MainMenu";

    public void LoadScene(string p_sceneName)
    {
        if (SceneManager.GetSceneByName(p_sceneName) != null)
        {
            SceneManager.LoadSceneAsync(p_sceneName);
        }
        else
        {
            Debug.LogError("Scene '" + p_sceneName + "' does not exist.");
        }
    }

    public void PlayGame()
    {
        LoadScene(_SampleSceneString);
    }

    public void GoToSettingsMenu()
    {
        LoadScene(_SettingsMenuString);
    }

    public void GoToMainMenu()
    {
        LoadScene(_MainMenuString);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
