using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public void OnResumeClicked()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

    public void OnRetryClicked()
    {
        SceneManager.LoadScene(_level);
    }

    public void OnOptionsClicked()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void OnHoneClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
