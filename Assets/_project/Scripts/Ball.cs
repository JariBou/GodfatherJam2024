using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    public class Ball : MonoBehaviour
    {
        public enum Type
        {
            Player, Master 
        }
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Ball.Type _ballType;
        [SerializeField] private Vector3 _dir;
        [SerializeField] private float _speed;

        [SerializeField] private float _destroyDelay = .0f;
        
        private Vector3 _ballVelocity;
        private Vector3 _angVelocity;

        public Type BallType => _ballType;

        public Vector3 Dir => _dir;

        private void Awake()
        {
            UpdateDir(_dir);
            _rb.velocity = _ballVelocity;
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector3(_ballVelocity.x, _rb.velocity.y, _ballVelocity.z);
            _rb.angularVelocity = _angVelocity;
        }

        public void UpdateDir(Vector3 newDir)
        {
            _dir = newDir;
            _ballVelocity = _dir.normalized * _speed;
        }
        
        
        public void Config(Vector3 ballDir, float ballSpeed, Type ballType)
        {
            _speed = ballSpeed;
            UpdateDir(ballDir);
            _ballType = ballType;
            gameObject.layer = ballType switch
            {
                Type.Player => 7 // Balls layer 
                ,
                Type.Master => 6 // MAsterBalls layer, not a fan of hardcoding but for now this will do
                ,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            // ================ TEMP ================
            switch (ballType)
            {
                case Type.Player:
                    _angVelocity = Vector3.up * Random.Range(1f, 5f) * Mathf.Sign(Random.Range(-1f, 1f));
                    break;
                case Type.Master:
                    GetComponent<MeshRenderer>().material.color = Color.magenta;
                    
                    transform.rotation = Quaternion.LookRotation(Quaternion.AngleAxis(30, Vector3.up) * _dir);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ballType), ballType, null);
            }
        }

        public void DestroyBall()
        {
            if (_destroyDelay > 0.00001f)
            {
                StartCoroutine(DelayedDestroyBall(_destroyDelay));
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator DelayedDestroyBall(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            // VFX Goes Here
            // yield return new WaitForSeconds(VFX_time); // potentially could work if some way to get animation length like with animator 
            
            Destroy(gameObject);
        }

        private void OnValidate()
        {
            gameObject.layer = _ballType switch
            {
                Type.Player => 7 // Balls layer 
                ,
                Type.Master => 6 // MAsterBalls layer, not a fan of hardcoding but for now this will do
                ,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

    }
}
