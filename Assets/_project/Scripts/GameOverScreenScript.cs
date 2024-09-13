using System;
using TMPro;
using UnityEngine;

namespace _project.Scripts
{
    public class GameOverScreenScript : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _loseText;
        [SerializeField] private GameObject _winText;
        [SerializeField] private ParticleSystem _coinsDrop;
        [SerializeField] private ParticleSystem _crabDrop;

        private void Start()
        {
            _panel.SetActive(false);
        }

        public void Display(bool state)
        {
            _panel.SetActive(true);
            if (state)
            {
                _winText.SetActive(true);
                _coinsDrop.Play();
            }
            else
            {
                _loseText.SetActive(false);
                _crabDrop.Play();
            }
        }
        
        private void OnGameOver(bool state)
        {
            Display(state);
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
