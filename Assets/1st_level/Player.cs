using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    private DefaultInputActions _defaultPlayerActions;

    // public Transform groundCheck;
    // private LayerMask _groundLayerMask;
    private float _speed = 6f;
    // private float _jumpforce = 6f;
    // private bool _isGrounded;

    private InputAction _moveAction;
    private InputAction _lookAction;


    private void Awake()
    {
        _defaultPlayerActions = new DefaultInputActions();
        // _groundLayerMask = LayerMask.GetMask("Ground");
    }

    private void OnEnable()
    {
        _moveAction = _defaultPlayerActions.Player.Move;
        _moveAction.Enable();
        _lookAction = _defaultPlayerActions.Player.Look;
        _lookAction.Enable();
        
        // _defaultPlayerActions.Player.Jump.performed += OnJump;
        // _defaultPlayerActions.Player.Jump.Enable();

    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
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

        float _limit = 30f;

        float _force = 0.5f;
            
        if(local_x > _limit)
            transform.Rotate(-_force, 0, 0);
        else if (local_x < -_limit)
            transform.Rotate(_force, 0, 0);
        else if (local_z > _limit)
            transform.Rotate(0, 0, -_force);
        else if (local_z < -_limit)
            transform.Rotate(0, 0, _force);
        else
            transform.Rotate(moveDir.y * _force, 0, moveDir.x * _force);

        // Console.Write("X :" + local_x + " | Y : " + local_y);

        Vector2 lookDir = _lookAction.ReadValue<Vector2>();
    }
}
