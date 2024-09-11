using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField, Range(0, 500)] private float _speed;
        [SerializeField] private GameManager _gameManager;
        private Vector3 _moveVec;
        
        public static event Action<Ball.Type> PlayerBallCollision; 
        
        private void FixedUpdate()
        {
            if (_moveVec.magnitude > 0.001)
            {
                _rb.velocity = new Vector3(_moveVec.x, _rb.velocity.y, _moveVec.z);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.GetComponent<Ball>()) return;
        
            Ball ballScript = other.gameObject.GetComponent<Ball>();
            PlayerBallCollision?.Invoke(ballScript.BallType);
            
            ballScript.DestroyBall();
        }

        public void Move(InputAction.CallbackContext ctx)
        {
            Vector2 val = ctx.ReadValue<Vector2>();
            _moveVec = new Vector3(val.x, _rb.velocity.y, val.y).normalized * _speed;
        }


    }
}
    
