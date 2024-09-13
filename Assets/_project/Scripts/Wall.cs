using System;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace _project.Scripts
{
    public class Wall : MonoBehaviour
    {
        public enum Type {
            Red, Blue, Yellow, Bouncy
        }

        [SerializeField] private Wall.Type _wallType;
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _hasAnimOnHit;

        // ============ Movement ============
        [SerializeField, OnValueChanged("OnMoveChanged")] private bool _moves;
        [SerializeField] private AnimationCurve _movementCurve;
        [SerializeField, Range(0f, 5f)] private float _movementSpeed;
        private Vector3 _startingPosition;
        [SerializeField, HideInInspector] private Transform _targetTransform;
        private Vector3 _snapshotTargetPosition;
        private float _internalTimer;

        private bool _isActivated = true;

        public Type WallType => _wallType;
        public bool IsInactive => !_isActivated;

        private void Awake()
        {
            if (_moves)
            {
                _startingPosition = transform.position;
                _snapshotTargetPosition = _targetTransform.position;
                Destroy(_targetTransform.gameObject);
            }
        }

        private void Update()
        {
            if (_moves && _isActivated)
            {
                float pingPongVal = Mathf.PingPong(_internalTimer, 1);
                float lerpT = _movementCurve.Evaluate(pingPongVal);
                transform.position =
                    Vector3.Lerp(_startingPosition, _snapshotTargetPosition, lerpT);
                _internalTimer += Time.deltaTime * _movementSpeed;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.GetComponent<Ball>() || !_isActivated) return; // TEMP "!_isActivated"
        
            Ball ballScript = other.gameObject.GetComponent<Ball>();

            switch (WallType)
            {
                case Type.Red or Type.Blue or Type.Yellow:
                    if (ballScript.BallType == Ball.Type.Master) return;
                    ballScript.DestroyBall();
                    break;
                case Type.Bouncy:
                    Vector3 newBallDir = Vector3.Reflect(ballScript.Dir, other.GetContact(0).normal);
                    ballScript.UpdateDir(newBallDir);
                    if (_hasAnimOnHit)
                    {
                        _animator.SetTrigger("OnHit");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Activate()
        {
            if (_wallType == Type.Bouncy)
            {
                _isActivated = true;
                return;
            }
            // float height = GetComponent<MeshRenderer>().bounds.extents.y * 2;
            float height = 2000;
            transform.position += new Vector3(0, height, 0);
            _isActivated = true;
            //TODO + animation and stuff
        }

        public void Deactivate()
        {
            if (_wallType == Type.Bouncy)
            {
                _isActivated = false;
                return;
            }
            // float height = GetComponent<MeshRenderer>().bounds.extents.y * 2;
            float height = 2000;
            transform.position -= new Vector3(0, height, 0);
            _isActivated = false;
            
            //TODO + animation and stuff
        }

        public void SwitchState()
        {
            if (_isActivated) Deactivate();
            else Activate();
        }

        #if UNITY_EDITOR
        private void OnMoveChanged()
        {
            if (_moves)
            {
                Transform selfTransform = transform;
                GameObject obj = new ($"Target of '{gameObject.name}'")
                {
                    transform =
                    {
                        parent = selfTransform,
                        position = selfTransform.position,
                    }
                };
                _targetTransform = obj.transform;
                Selection.activeGameObject = obj;
                SceneView.FrameLastActiveSceneView();
            }
            else
            {
                if (_targetTransform != null)
                {
                    DestroyImmediate(_targetTransform.gameObject);
                }
            }
        }
        #endif
    }
}
