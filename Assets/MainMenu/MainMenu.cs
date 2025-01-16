using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Timer timer;

    public AudioSource Music;

    void Start()
    {
        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
        Music.volume = Options.Instance.MusicLevel;
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OnOptionsClicked()
    {
        SceneManager.LoadScene("OptionMenu", LoadSceneMode.Additive);
    }

    public void OnQuitClicked()
    {
        Destroy(timer);
        Application.Quit();
    }
}
