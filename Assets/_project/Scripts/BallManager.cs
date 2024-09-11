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
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void AttemptSpawn()
        {
            Bounds bounds = _ballPrefab.gameObject.GetComponent<MeshRenderer>().bounds;

            Vector3 sp = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;

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
    }
}
