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
        [SerializeField] private float _ballHellSpawnCooldown = 0.15f;
        [SerializeField] private float _ballHellSpawnCooldownRange = 0.05f;
        
        private PlayerInputs _inputs;

        private void Awake()
        {
            _inputs = new PlayerInputs();
            
            // ================== Player Inputs ==================
            _inputs.PlayerMap.Move.performed += _player.Move;
            _inputs.PlayerMap.Move.canceled += _player.Move;
        
            // ================== Master Inputs ==================
            _inputs.MasterMap.RandomRedWalls.performed += _ => { _wallManager.ActivateRandomWallFromType(Wall.Type.Red); };
            _inputs.MasterMap.RandomBlueWalls.performed += _ => { _wallManager.ActivateRandomWallFromType(Wall.Type.Blue); };
            _inputs.MasterMap.RandomYellowWalls.performed += _ => { _wallManager.ActivateRandomWallFromType(Wall.Type.Yellow); };
            _inputs.MasterMap.RedWallsRemoval.performed += _ => { _wallManager.DeactivateAllWallsFromType(Wall.Type.Red); };
            _inputs.MasterMap.BlueWallsRemoval.performed += _ => { _wallManager.DeactivateAllWallsFromType(Wall.Type.Blue); };
            _inputs.MasterMap.YellowWallsRemoval.performed += _ => { _wallManager.DeactivateAllWallsFromType(Wall.Type.Yellow); };
            
            _inputs.MasterMap.SpawnSpeedChange.performed += ctx =>
            {
                _ballManager.ModifySpawnSpeed(_spawnSpeedIncrement * Math.Sign(ctx.ReadValue<float>()));
            };
            _inputs.MasterMap.BallSpeedChange.performed += ctx =>
            {
                _ballManager.ModifyBallSpeed(_ballSpeedIncrement * Math.Sign(ctx.ReadValue<float>()));
            };

            _inputs.MasterMap.MasterBallHell.performed += _ =>
            {
                _wallManager.ActivateAllWalls();
                _ballManager.DoBallHell(Ball.Type.Master, _ballHellDuration, _ballHellSpawnCooldown, _ballHellSpawnCooldownRange);
            };
            _inputs.MasterMap.PlayerBallHell.performed += _ =>
            {
                _wallManager.DeactivateAllWalls();
                _ballManager.DoBallHell(Ball.Type.Player, _ballHellDuration, _ballHellSpawnCooldown, _ballHellSpawnCooldownRange);
            };
        }
        
        
        private void OnGameOver(bool state)
        {
            if (state)
            {
                DisableMasterInput();
            }
            else
            {
                DisableInputs();
            }
        }

        #region Inputs Enabling/disabling

        public void EnableInputs()
        {
            EnablePlayerInput();
            EnableMasterInput();
        }

        public void DisableInputs()
        {
            DisablePlayerInput();
            DisableMasterInput();
        }
        
        public void EnablePlayerInput()
        {
            _inputs.PlayerMap.Enable();
        }
        
        public void DisablePlayerInput()
        {
            _inputs.PlayerMap.Disable();
        }

        public void EnableMasterInput()
        {
            _inputs.MasterMap.Enable();
        }
        
        public void DisableMasterInput()
        {
            _inputs.MasterMap.Disable();
        }

        #endregion
        
        private void OnEnable()
        {
            EnableInputs();
            GameManager.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            DisableInputs();
            GameManager.GameOver -= OnGameOver;
        }
    }
}
