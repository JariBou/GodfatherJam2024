using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    public class BallManager : MonoBehaviour
    {
        [Header("Spawnpoints Params"), SerializeField] private float _cooldownPerSpawn = 3f;
        [SerializeField] private float _cooldownPerSpawnRandomRange = .0f;
        [SerializeField] private float _ballsPerSpawnPhase = 1;
        [SerializeField] private float _cooldownPerSpawnAttempt = 0.5f;
        [SerializeField] private float _cooldownPerSpawnAttemptRandomRange = .0f;
        [SerializeField, SerializedDictionary("Spawnpoint", "Offset Range")]
        private SerializedDictionary<Transform, Vector3> _spawnpointsOffsetDic;
        
        [Header("Target Point Params"), SerializeField] private Transform _target;
        [FormerlySerializedAs("_offsetRadiusMax")] [SerializeField] private float _targetOffsetRadiusMax;
        
        [Header("Ball Params"), SerializeField] private GameObject _ballPrefab;
        [SerializeField] private float _ballSpeed = 5f;
        [SerializeField, Tooltip("Percent of balls generated that will 'hurt' the player")] private float _masterBallRatio = .6f;
        // Can easily add an animation curve to make it more probable to be closer to center and stuff
        //[SerializeField] private List<Transform> _spawnPoints; 


        private float _internalTimer;
        private float _spawnAttemptInternalTimer;
        private float _spawnAttemptInternalCounter;
        private readonly RaycastHit[] _hits = {};
        
        // Master Variables
        private float _spawnCooldownMultiplier = 1f;
        private float _ballSpeedMultiplier = 1f;
        
        
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
            // Bounds bounds = _ballPrefab.gameObject.GetComponent<MeshRenderer>().bounds;

            int randomSpawnIndex = Random.Range(0, _spawnpointsOffsetDic.Keys.Count);
            Transform spawnPointTransform = _spawnpointsOffsetDic.Keys.ToList()[randomSpawnIndex];
            
            Vector3 spawnPoint = spawnPointTransform.position;
            Vector3 offsetRange = _spawnpointsOffsetDic[spawnPointTransform];
            spawnPoint += new Vector3(Random.Range(-offsetRange.x, offsetRange.x), Random.Range(-offsetRange.y, offsetRange.y), Random.Range(-offsetRange.z, offsetRange.z));
            
            Physics.SphereCastNonAlloc(spawnPoint, 2,
                Vector3.down, _hits);
            foreach (RaycastHit hit in _hits)
            {
                if (hit.collider.GetComponent<Ball>())
                {
                    AttemptSpawn(attemptCount+1);
                    return;
                }
            }

            GenerateBall(spawnPoint);

            if (Math.Abs(_spawnAttemptInternalCounter - (_ballsPerSpawnPhase - 1)) < 0.0001f) StartCoroutine(DoSpawnPhaseCooldown());
            else
            {
                _spawnAttemptInternalCounter++;
                StartCoroutine(DoSpawnAttemptCooldown());
            }
        }

        private void GenerateBall(Vector3 spawnPoint)
        {
            Ball spawnedBall = Instantiate(_ballPrefab, spawnPoint, Quaternion.identity, transform).GetComponent<Ball>();
            Vector3 targetPos = _target.position + new Vector3(Random.Range(-_targetOffsetRadiusMax, _targetOffsetRadiusMax), 0,
                Random.Range(-_targetOffsetRadiusMax, _targetOffsetRadiusMax));
            Vector3 ballDir = targetPos - spawnPoint;

            Ball.Type spawnedBallType = Random.Range(0f, 1f) < _masterBallRatio ? Ball.Type.Master : Ball.Type.Player;
            
            spawnedBall.Config(ballDir, _ballSpeed * _ballSpeedMultiplier, spawnedBallType);
        }

        private IEnumerator DoSpawnPhaseCooldown()
        {
            _spawnAttemptInternalCounter = 0;
            yield return new WaitForSeconds(_cooldownPerSpawn * _spawnCooldownMultiplier + Random.Range(-_cooldownPerSpawnRandomRange, _cooldownPerSpawnRandomRange));
            AttemptSpawn();
        }
        
        private IEnumerator DoSpawnAttemptCooldown()
        {
            yield return new WaitForSeconds(_cooldownPerSpawnAttempt + Random.Range(-_cooldownPerSpawnAttemptRandomRange, _cooldownPerSpawnAttemptRandomRange));
            AttemptSpawn();
        }

        public void ModifySpawnSpeed(float multDelta)
        {
            _spawnCooldownMultiplier += multDelta;
            if (_spawnCooldownMultiplier <= 0)
            {
                _spawnCooldownMultiplier = Math.Abs(multDelta);
            }
        }
        
        public void ModifyBallSpeed(float multDelta)
        {
            _ballSpeedMultiplier += multDelta;
            if (_ballSpeedMultiplier <= 0)
            {
                _ballSpeedMultiplier = Math.Abs(multDelta);
            }
        }

        private void OnValidate()
        {
            if (_ballPrefab != null && _ballPrefab.GetComponent<Ball>() == null) _ballPrefab = null;
        }
    }
}
