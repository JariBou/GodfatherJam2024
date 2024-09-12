using System;
using UnityEngine;

namespace _project.Scripts
{
    public class InputManager : MonoBehaviour
    {
        [Header("Refs"), SerializeField] private WallManager _wallManager;
        [SerializeField] private Player _player;
        [SerializeField] private BallManager _ballManager;
        [Header("Master inputs params"),SerializeField] private float _spawnSpeedIncrement = .1f;
        [SerializeField] private float _ballSpeedIncrement = .1f;
        
        private PlayerInputs _inputs;

        private void Awake()
        {
            _inputs = new PlayerInputs();
            
            // ================== Player Inputs ==================
            _inputs.PlayerMap.Move.performed += _player.Move;
            _inputs.PlayerMap.Move.canceled += _player.Move;
        
            // ================== Master Inputs ==================
            _inputs.PlayerMap.RedWalls.performed += _ => { _wallManager.ActivateWallType(Wall.Type.Red); };
            _inputs.PlayerMap.BlueWalls.performed += _ => { _wallManager.ActivateWallType(Wall.Type.Blue); };
            _inputs.PlayerMap.YellowWalls.performed += _ => { _wallManager.ActivateWallType(Wall.Type.Yellow); };
            _inputs.PlayerMap.SpawnSpeedChange.performed += ctx =>
            {
                _ballManager.ModifySpawnSpeed(_spawnSpeedIncrement * Math.Sign(ctx.ReadValue<float>()));
            };
            _inputs.PlayerMap.BallSpeedChange.performed += ctx =>
            {
                _ballManager.ModifyBallSpeed(_ballSpeedIncrement * Math.Sign(ctx.ReadValue<float>()));
            };
        }
        
        
        private void OnEnable()
        {
            _inputs.PlayerMap.Enable();
        }

        private void OnDisable()
        {
            _inputs.PlayerMap.Disable();
        }
    }
}
