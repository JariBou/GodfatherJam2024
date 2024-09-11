using UnityEngine;

namespace _project.Scripts
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private WallManager _wallManager;
        [SerializeField] private Player _player;
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
