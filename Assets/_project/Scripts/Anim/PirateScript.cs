using System;
using _project.Scripts.Manager;
using UnityEngine;

namespace _project.Scripts.Anim
{
    public class PirateScript : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _particles;
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_player == null) return;
            Vector3 dir = _player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(-90, 0, angle);
        }

        public void PirateDeath()
        {
            Instantiate(_particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        private void OnGameOver(bool state)
        {
            _animator.enabled = true;
            _animator.SetBool("PlayerWon", state);
            if (state) _animator.SetTrigger("PlayerWonT");
            _animator.SetBool("PlayerLost", !state);
            if (!state) _animator.SetTrigger("PlayerLostT");
        }

        private void OnEnable()
        {
            GameManager.GameOver += OnGameOver;
        }
        
        private void OnDisable()
        {
            GameManager.GameOver -= OnGameOver;
        }

        
    }
}
