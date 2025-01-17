using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndLevel : MonoBehaviour
{
    private string _level;

    private string _timer;

    [SerializeField] public TMP_Text _level_text;
    [SerializeField] public TMP_Text _timer_text;

    public TMP_Text[] _timers;

    public TMP_Text[] _levels;

    public AudioSource Music;

    private AudioSource mainTheme;
    private bool MainThemeNotReady = true;

    private readonly string[] saveLevelkeys = {"Level1", "Level2", "Level3"};

    void Start()
    {

        PlayerPrefs.SetString("Level1", "00 : 51");
        PlayerPrefs.SetString("Level2", "00 : 52");
        PlayerPrefs.SetString("Level3", "00 : 53");

        _timer = PlayerPrefs.GetString("timer");
        _level = PlayerPrefs.GetString("level");


        if(_level[^1] == 3)
            setAllScores();
        else
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

    private void setAllScores()
    {
        if(_timers.Length < 3 || _levels.Length < 3)
        return;

        for(int i = 0; i < saveLevelkeys.Length; i++)
        {
            _timers[i].text = PlayerPrefs.GetString(saveLevelkeys[i]);
            _levels[i].text = saveLevelkeys[i];
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

        PlayerPrefs.SetString(saveLevelkeys[level], _timer);
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
