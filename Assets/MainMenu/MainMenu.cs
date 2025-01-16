using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Timer timer;

    public AudioSource Music;

    private string _scene_name;

    private bool isMusicUpdated = true;

    void Awake()
    {
        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
        Music.volume = Options.Instance.MusicLevel / 4;
        _scene_name = SceneManager.GetActiveScene().name;
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

    public void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == _scene_name && !isMusicUpdated)
        {
            Music.volume = Options.Instance.MusicLevel / 4;
            isMusicUpdated = true;
        }else
        {
            isMusicUpdated = false;
        }
    }
}
