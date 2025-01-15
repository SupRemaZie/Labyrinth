using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Timer timer;

    void Start()
    {
        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OnOptionsClicked()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void OnQuitClicked()
    {
        Destroy(timer);
        Application.Quit();
    }
}
