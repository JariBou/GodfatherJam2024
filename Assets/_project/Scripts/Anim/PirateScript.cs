using System;
using UnityEngine;

namespace _project.Scripts.Anim
{
    public class PirateScript : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _particles;
        [SerializeField] private Animator _animator;

        // Update is called once per frame
        void Update()
        {
            Vector3 dir = _player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(-90, 0, angle);
        }

        public void PirateDeath()
        {
            Instantiate(_particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        private void OnGameOver(bool obj)
        {
            _animator.SetBool("PlayerWon", obj);
            _animator.SetBool("PlayerWon", !obj);
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
