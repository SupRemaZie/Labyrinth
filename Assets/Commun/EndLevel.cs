using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndLevel : MonoBehaviour
{
    private string _level;

    private string _timer;

    [SerializeField] public TMP_Text _level_text;
    [SerializeField] public TMP_Text _timer_text;

    public AudioSource Music;

    private AudioSource mainTheme;
    private bool MainThemeNotReady = true;

    void Start()
    {
        _timer = PlayerPrefs.GetString("timer");
        _level = PlayerPrefs.GetString("level");

        setText();

        Music.volume = Options.Instance.SoundsLevel / 2;

        Music.Play();

        mainTheme = gameObject.GetComponent<AudioSource>();
        mainTheme.volume = Options.Instance.MusicLevel / 10;
        mainTheme.Play();

    }

    void FixedUpdate()
    {
        if(!Music.isPlaying && MainThemeNotReady)
        {
            // Debug.Log("Je change de morceaux !");
            mainTheme.volume = Options.Instance.MusicLevel / 4;
            MainThemeNotReady = false;
        }
    }

    private void setText()
    {
        _level_text.text = _level + " Finished !";
        _timer_text.text = "Time : " + _timer;
    }

    public void OnHomeClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRetryClicked()
    {
        SceneManager.LoadScene(_level);
    }

    public void OnNextClicked()
    {
        char lastcaracter = _level[^1];
        int level = (int)char.GetNumericValue(lastcaracter);
        SceneManager.LoadScene("Level_" + (level + 1));
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
