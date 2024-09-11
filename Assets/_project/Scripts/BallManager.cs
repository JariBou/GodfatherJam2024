using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private float _cooldwonPerSpawn = 3f;
        [SerializeField] private float _cooldownPerSpawnRandomRange = .0f;
        [SerializeField] private float _ballsPerSpawnPhase = 1;
        [SerializeField] private float _cooldownPerSpawnAttempt = 0.5f;
        [SerializeField] private float _cooldownPerSpawnAttemptRandomRange = .0f;
        [SerializeField] private float _ballSpeed = 5f;
        [SerializeField] private Transform _target;
        [SerializeField] private float _offsetRadiusMax;
        // Can easily add an animation curve to make it more probable to be closer to center and stuff
        [SerializeField] private List<Transform> _spawnPoints; // TODO: Use Graphics labor for a serialized dictionary with possible offset

        private float _internalTimer;
        private float _spawnAttemptInternalTimer;
        private float _spawnAttemptInternalCounter;
        private RaycastHit[] _hits = {};
        
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(DoSpawnPhaseCooldown());
        }

        private void AttemptSpawn(int attemptCount = 0)
        {
            if (attemptCount > 20)
            {
                return;
            }
            Bounds bounds = _ballPrefab.gameObject.GetComponent<MeshRenderer>().bounds;

            Vector3 spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            Physics.SphereCastNonAlloc(spawnPoint, Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z),
                Vector3.down, _hits);
            foreach (RaycastHit hit in _hits)
            {
                if (hit.collider.GetComponent<Ball>())
                {
                    AttemptSpawn(attemptCount++);
                    return;
                }
            }

            Ball spawnedBall = Instantiate(_ballPrefab, spawnPoint, Quaternion.identity, transform).GetComponent<Ball>();
            Vector3 targetPos = _target.position + new Vector3(Random.Range(-_offsetRadiusMax, _offsetRadiusMax), 0,
                Random.Range(-_offsetRadiusMax, _offsetRadiusMax));
            Vector3 ballDir = targetPos - spawnPoint;
            spawnedBall.Config(ballDir, _ballSpeed, Ball.Type.Player);

            // DO Spawning here

            if (Math.Abs(_spawnAttemptInternalCounter - (_ballsPerSpawnPhase - 1)) < 0.0001f) StartCoroutine(DoSpawnPhaseCooldown());
            else
            {
                _spawnAttemptInternalCounter++;
                StartCoroutine(DoSpawnAttemptCooldown());
            }
        }

        private IEnumerator DoSpawnPhaseCooldown()
        {
            _spawnAttemptInternalCounter = 0;
            yield return new WaitForSeconds(_cooldwonPerSpawn + Random.Range(-_cooldownPerSpawnRandomRange, _cooldownPerSpawnRandomRange));
            AttemptSpawn();
        }
        
        private IEnumerator DoSpawnAttemptCooldown()
        {
            yield return new WaitForSeconds(_cooldownPerSpawnAttempt + Random.Range(-_cooldownPerSpawnAttemptRandomRange, _cooldownPerSpawnAttemptRandomRange));
            AttemptSpawn();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnValidate()
        {
            if (_ballPrefab != null && _ballPrefab.GetComponent<Ball>() == null) _ballPrefab = null;
        }
    }
}
