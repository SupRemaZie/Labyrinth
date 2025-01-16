using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    private string _level;

    private string _timer;

    [SerializeField] public TMP_Text _level_text;
    [SerializeField] public TMP_Text _timer_text;

    void Start()
    {
        _timer = PlayerPrefs.GetString("timer");
        _level = PlayerPrefs.GetString("level");

        setText();
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
}
