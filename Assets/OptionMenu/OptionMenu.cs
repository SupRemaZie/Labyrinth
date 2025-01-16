using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    public TMP_Dropdown _color;

    [SerializeField]
    public Toggle _backgroundMusicToggle;

    [SerializeField]
    public Slider _slider;

    [SerializeField]
    public TMP_Text _music_level;


    public void Start()
    {
        _backgroundMusicToggle.isOn = Options.Instance.IsBackgroundMusicEnabled;
        _color.value = Options.Instance.Color;

        _slider.onValueChanged.AddListener(delegate {OnUpdateMusicLevel();});

        _slider.value = Options.Instance.MusicLevel;
    }
    public void OnSaveClicked()
    {
        Options.Instance.IsBackgroundMusicEnabled = _backgroundMusicToggle.isOn;
        Options.Instance.Color = _color.value;
        Options.Instance.MusicLevel = _slider.value;
        if(SceneManager.loadedSceneCount > 1)
            SceneManager.UnloadSceneAsync("OptionMenu");
        else 
            SceneManager.LoadScene(PlayerPrefs.GetString("level"));
    }

    public void OnCancelClicked()
    {
        if(SceneManager.loadedSceneCount > 1)
            SceneManager.UnloadSceneAsync("OptionMenu");
        else 
            SceneManager.LoadScene(PlayerPrefs.GetString("level"));
    }

    public void OnUpdateMusicLevel()
    {
        _music_level.SetText(Convert.ToInt32(_slider.value*100) + " %");
    }
}
