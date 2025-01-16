using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    private DefaultInputActions _defaultPlayerActions;

    public Transform _ball;
    public AudioSource[] _sounds;
    public AudioSource Music;

    public float BaseMusicVolume;

    // public Transform groundCheck;
    // private LayerMask _groundLayerMask;
    private float _speed = 6f;
    // private float _jumpforce = 6f;
    // private bool _isGrounded;

    private Rigidbody _rigidbody;

    private InputAction _moveAction;

    private InputAction _cheatAction;

    void Start()
    {
        UpdateColorBall();
        UpdateMusicLevel();

        Music.Play();
        foreach(AudioSource audio in _sounds)
        {
            audio.Play();
        }

        _cheatAction.performed +=
        context => {
            if (SceneManager.GetActiveScene().name == "Level_3")
            {
                SceneManager.LoadScene("EndGame");
            }
            else
            {
                SceneManager.LoadScene("EndLevel");
            }
        };
    }

    private void Awake()
    {
        _defaultPlayerActions = new DefaultInputActions();
        // _groundLayerMask = LayerMask.GetMask("Ground");
        _rigidbody = gameObject.GetComponent<Rigidbody>();

        UpdateMusicLevel();
    }

    private void OnEnable()
    {
        _moveAction = _defaultPlayerActions.Player.Move;
        _moveAction.Enable();
        
        _cheatAction = _defaultPlayerActions.Player.Cheat;
        _cheatAction.Enable();
        
        UpdateMusicLevel();
        
        // _defaultPlayerActions.Player.Jump.performed += OnJump;
        // _defaultPlayerActions.Player.Jump.Enable();

    }

    private void OnDisable()
    {
        _moveAction.Disable();

        _cheatAction.Disable();
        // _defaultPlayerActions.Player.Jump.performed -= OnJump;
        // _defaultPlayerActions.Player.Jump.Disable();
    }

    // private void OnJump(InputAction.CallbackContext context)
    // {
    //     if (_isGrounded)
    //         _rigidbody.AddForce(Vector3.up * _jumpforce, ForceMode.Impulse);
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        // _isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.05f, _groundLayerMask);

        Vector2 moveDir = _moveAction.ReadValue<Vector2>();
        // Vector3 vel = _rigidbody.linearVelocity;
        // vel.x = _speed * moveDir.x;
        // vel.z = _speed * moveDir.y;
        // _rigidbody.linearVelocity = vel;

        float local_x = transform.localRotation.eulerAngles.x;
        float local_z = transform.localRotation.eulerAngles.z;

        local_x %=360;
        local_x= local_x>180 ? local_x-360 : local_x;

        local_z %=360;
        local_z= local_z>180 ? local_z-360 : local_z;

        float _force = 0.25f;

        _rigidbody.AddTorque(moveDir.y * _force, 0, -moveDir.x * _force, ForceMode.Force);

    }

    public void UpdateColorBall()
    {
        Renderer ballRenderer = _ball.GetComponent<Renderer>();
        Color color;
        ColorUtility.TryParseHtmlString(Options.Instance.GetColorHexa(), out color);
        ballRenderer.material.color = color;
    }

    public void UpdateMusicLevel()
    {
        foreach(AudioSource audio in _sounds)
        {
            audio.volume = Options.Instance.SoundsLevel;
        }
        Music.volume = BaseMusicVolume * Options.Instance.MusicLevel;


        // Debug.Log(Options.Instance.MusicLevel);
    }

    public void PauseMusic()
    {
        foreach(AudioSource audio in _sounds)
            {
                audio.Pause();
            }
        
        
        Music.Pause();

        // Debug.Log("Trying to pause : " + Music.name);
    }

    public void ResumeMusic()
    {
        foreach(AudioSource audio in _sounds)
            {
                audio.Play();
            }


        Music.Play();
        // Debug.Log("Trying to play : " + Music.name);
    }
}
