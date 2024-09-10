using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField, Range(0, 500)] private float _speed;
    private PlayerInputs _playerInputs;
    private Vector3 _moveVec;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    private void FixedUpdate()
    {
        if (_moveVec.magnitude > 0.001)
        {
            _rb.velocity = _moveVec;
        }

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 val = ctx.ReadValue<Vector2>();
        _moveVec = new Vector3(val.x, _rb.velocity.y, val.y).normalized * _speed;
    }

    private void OnEnable()
    {
        _playerInputs.PlayerMap.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.PlayerMap.Disable();
    }

}
    
