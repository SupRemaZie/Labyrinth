using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    private string _color;
    [SerializeField]
    private bool _backgroundMusicToggle;
    public void Start()
    {
        _backgroundMusicToggle = Options.Instance.IsBackgroundMusicEnabled;
    }
    public void OnSaveClicked()
    {
        Options.Instance.IsBackgroundMusicEnabled = _backgroundMusicToggle;
        SceneManager.LoadScene(0);
    }

    public void SetBackgroundMusic(bool value)
    {
        _backgroundMusicToggle = value;
    }

    public void OnCancelClicked()
    {
        SceneManager.LoadScene(0);
    }
}
