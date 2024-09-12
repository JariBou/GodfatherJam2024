using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _project.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField, Range(0, 20)] private float _drag = 1.7f;
        [SerializeField, Range(1, 200)] private float _appliedForceStrength = 60f;
        [FormerlySerializedAs("_speed")] [SerializeField, Range(0, 400)] private float _maxSpeed = 200f;
        [SerializeField, Range(1f, 5f)] private float _angularSpeed = 3f;
        [SerializeField] private GameObject _playerBallPickupParticle; 
        [SerializeField] private GameObject _masterBallPickupParticle; 
        
        private Vector3 _moveVec;
        private Transform _startTransform;
        private bool _isPickupActive = true;
        
        public static event Action<Ball.Type> PlayerBallCollision;

        private void Awake()
        {
            _startTransform = transform;
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, _moveVec, _angularSpeed * Time.deltaTime, 0.0f));
        }

        private void FixedUpdate()
        {
            if (!(_moveVec.magnitude > 0.001)) return;
            
            _rb.AddForce(_moveVec * _appliedForceStrength);
            Vector3 planarMovement = new (_rb.velocity.x, 0, _rb.velocity.z);
            Vector3 clampedPlanarMovement = Vector3.ClampMagnitude(planarMovement, _maxSpeed);
            _rb.velocity = new Vector3(clampedPlanarMovement.x, _rb.velocity.y, clampedPlanarMovement.z);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.GetComponent<Ball>()) return;
            Ball ballScript = other.gameObject.GetComponent<Ball>();
            
            if(_isPickupActive) PlayerBallCollision?.Invoke(ballScript.BallType);
            switch (ballScript.BallType)
            {
                case Ball.Type.Player:
                    Instantiate(_playerBallPickupParticle, transform.position, Quaternion.identity);
                    break;
                case Ball.Type.Master:
                    Instantiate(_masterBallPickupParticle, transform.position, Quaternion.identity);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            ballScript.DestroyBall();
        }

        public void Move(InputAction.CallbackContext ctx)
        {
            Vector2 val = ctx.ReadValue<Vector2>();
            _moveVec = new Vector3(val.x, 0, val.y).normalized;
        }
        
        private void OnGameOver(bool state)
        {
            _isPickupActive = false;
        }

        private void OnEnable()
        {
            GameManager.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            GameManager.GameOver -= OnGameOver;
        }

        private void OnValidate()
        {
            _rb.drag = _drag;
        }

        public void Respawn()
        {
            transform.position = _startTransform.position;
            transform.rotation = _startTransform.rotation;
        }
    }
}
    
