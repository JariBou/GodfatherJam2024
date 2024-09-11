using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField] private float _spawnCooldown = 3f;
        [SerializeField] private float _ballsPerSpawnAttempt = 1;
        [SerializeField] private float _cooldownPerSpawnAttempt = 0.5f;
        [SerializeField] private float _ballSpeed = 5f;
        [SerializeField] private Transform _target;
        [SerializeField] private float _offsetRadiusMax;
        // Can easily add an animation curve to make it more probable to be closer to center and stuff
        [SerializeField] private List<Transform> _spawnPoints; // TODO: Use Graphics labor for a serialized dictionnary with possible offset

        private float _internalTimer;
        private float _spawnAttemptInternalTimer;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
