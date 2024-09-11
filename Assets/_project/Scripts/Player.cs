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
        private Vector3 _moveVec;
        
        public static event Action<Ball.Type> PlayerBallCollision; 
        
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
            PlayerBallCollision?.Invoke(ballScript.BallType);
            
            ballScript.DestroyBall();
        }

        public void Move(InputAction.CallbackContext ctx)
        {
            Vector2 val = ctx.ReadValue<Vector2>();
            _moveVec = new Vector3(val.x, 0, val.y).normalized;
        }

        private void OnValidate()
        {
            _rb.drag = _drag;
        }
    }
}
    
