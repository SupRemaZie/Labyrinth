using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    public TMP_Dropdown _color;
    [SerializeField]
    public Toggle _backgroundMusicToggle;


    public void Start()
    {
        _backgroundMusicToggle.isOn = Options.Instance.IsBackgroundMusicEnabled;
        _color.value = Options.Instance.Color;
    }
    public void OnSaveClicked()
    {
        Options.Instance.IsBackgroundMusicEnabled = _backgroundMusicToggle.isOn;
        Options.Instance.Color = _color.value;
        SceneManager.LoadScene(PlayerPrefs.GetString("level"));
    }

    public void OnCancelClicked()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("level"));
    }
}
