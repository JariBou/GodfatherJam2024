using System;
using TMPro;
using UnityEngine;

namespace _project.Scripts
{
    public class GameOverScreenScript : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private TMP_Text _stateText;

        private void Start()
        {
            _panel.SetActive(false);
        }

        public void Display(bool state)
        {
            _panel.SetActive(true);
            _stateText.text = state ? "Won" : "Lost";
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
