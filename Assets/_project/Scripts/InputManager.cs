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
        [SerializeField] private float _ballHellDuration = 5f;
        
        private PlayerInputs _inputs;

        private void Awake()
        {
            _inputs = new PlayerInputs();
            
            // ================== Player Inputs ==================
            _inputs.PlayerMap.Move.performed += _player.Move;
            _inputs.PlayerMap.Move.canceled += _player.Move;
        
            // ================== Master Inputs ==================
            _inputs.PlayerMap.RandomRedWalls.performed += _ => { _wallManager.ActivateRandomWallFromType(Wall.Type.Red); };
            _inputs.PlayerMap.RandomBlueWalls.performed += _ => { _wallManager.ActivateRandomWallFromType(Wall.Type.Blue); };
            _inputs.PlayerMap.RandomYellowWalls.performed += _ => { _wallManager.ActivateRandomWallFromType(Wall.Type.Yellow); };
            _inputs.PlayerMap.RedWallsRemoval.performed += _ => { _wallManager.DeactivateAllWallsFromType(Wall.Type.Red); };
            _inputs.PlayerMap.BlueWallsRemoval.performed += _ => { _wallManager.DeactivateAllWallsFromType(Wall.Type.Blue); };
            _inputs.PlayerMap.YellowWallsRemoval.performed += _ => { _wallManager.DeactivateAllWallsFromType(Wall.Type.Yellow); };
            
            _inputs.PlayerMap.SpawnSpeedChange.performed += ctx =>
            {
                _ballManager.ModifySpawnSpeed(_spawnSpeedIncrement * Math.Sign(ctx.ReadValue<float>()));
            };
            _inputs.PlayerMap.BallSpeedChange.performed += ctx =>
            {
                _ballManager.ModifyBallSpeed(_ballSpeedIncrement * Math.Sign(ctx.ReadValue<float>()));
            };

            _inputs.PlayerMap.MasterBallHell.performed += _ =>
            {
                _ballManager.DoBallHell(Ball.Type.Master, _ballHellDuration);
            };
            _inputs.PlayerMap.PlayerBallHell.performed += _ =>
            {
                _ballManager.DoBallHell(Ball.Type.Player, _ballHellDuration);
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
