using System;
using UnityEngine;

namespace _project.Scripts
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _lerpFactor = 5f;

        private Quaternion _startRot;

        private void Awake()
        {
            _startRot = transform.rotation;
        }

        // Update is called once per frame
        void Update()
        {
            // Vector3 playerPos = _player.transform.position - _player.StartTransform.position;
            // Vector3 playerDividedPos =
            //     new Vector3(playerPos.x / _divisionFactor, playerPos.y, playerPos.z / _divisionFactor);
            // Vector3 playerTranslatedPos = playerDividedPos + new Vector3(_player.StartTransform.position.x, 0, _player.StartTransform.position.z);
            Vector3 direction =  _player.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(_startRot, Quaternion.LookRotation(direction), _lerpFactor);
            // transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
