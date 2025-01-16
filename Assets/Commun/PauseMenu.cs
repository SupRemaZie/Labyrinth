using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEditor.VersionControl;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    private DefaultInputActions _defaultPlayerActions;

    public GameObject pauseMenuUI;

    public Player _player;

    private InputAction _pauseAction;

        private void Awake()
    {
        _defaultPlayerActions = new DefaultInputActions();
    }

    private void OnEnable()
    {
        _pauseAction = _defaultPlayerActions.Player.Pause;
        _pauseAction.Enable();
        
        // _defaultPlayerActions.Player.Jump.performed += OnJump;
        // _defaultPlayerActions.Player.Jump.Enable();

    }

    private void OnDisable()
    {
        _pauseAction = _defaultPlayerActions.Player.Pause;
        _pauseAction.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _pauseAction.performed +=
        context => {
            if(GameIsPaused) Resume();
            else Pause();
        };
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        _player.UpdateColorBall();
        _player.isMusicActivated();
        _player.ResumeMusic();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        _player.PauseMusic();
    }

    public void Retry()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionMenu", LoadSceneMode.Additive);
    }

    public void ReturnToMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
}
