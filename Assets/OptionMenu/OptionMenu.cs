using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown Color;

    [SerializeField] public Slider MusicSlider;

    [SerializeField] public TMP_Text Music_level;

    [SerializeField] public Slider SoundsSlider;

    [SerializeField] public TMP_Text Sounds_level;


    public void Start()
    {
        Color.value = Options.Instance.Color;

        MusicSlider.onValueChanged.AddListener(delegate {OnUpdateMusicLevel();});
        SoundsSlider.onValueChanged.AddListener(delegate {OnUpdateSoundsLevel();});

        MusicSlider.value = Options.Instance.MusicLevel;
        SoundsSlider.value = Options.Instance.SoundsLevel;
    }
    public void OnSaveClicked()
    {
        Options.Instance.Color = Color.value;
        Options.Instance.MusicLevel = MusicSlider.value;
        Options.Instance.SoundsLevel = SoundsSlider.value;
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
        Music_level.SetText(Convert.ToInt32(MusicSlider.value*100) + " %");
    }

    public void OnUpdateSoundsLevel()
    {
        Sounds_level.SetText(Convert.ToInt32(SoundsSlider.value*100) + " %");
    }
}
