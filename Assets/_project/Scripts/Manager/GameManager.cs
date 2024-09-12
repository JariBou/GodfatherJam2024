using System;
using NaughtyAttributes;
using UnityEngine;

namespace _project.Scripts
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private int _maxScore = 100;
        [SerializeField] private int _startingScore = 50;
        [SerializeField, Foldout("Refs")] private VFXManager _vfxManager;
        [SerializeField, Foldout("Refs")] private BallManager _ballManager;
        [SerializeField, Foldout("Refs")] private InputManager _inputManager;
        [SerializeField, Foldout("Refs")] private GameOverScreenScript _gameOverScreenScript;

        private int _score;

        public static event Action<bool> GameOver; 

        private void Awake()
        {
            _score = _startingScore;
            _vfxManager.UpdateSlider(GetScorePercent());
        }

        // For Shader (ScoreDisplay)
        public float GetScorePercent()
        {
            return _score / (float) _maxScore;
        }
        
        private void OnPlayerBallCollision(Ball.Type ballType)
        {
            switch (ballType)
            {
                case Ball.Type.Player:
                    _score++;
                    break;
                case Ball.Type.Master:
                    _score--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ballType), ballType, null);
            }
            _vfxManager.UpdateSlider(GetScorePercent());
            CheckEndOfGame();
            // TODO
            // Check win con and update displays
        }

        private void CheckEndOfGame()
        {
            if (_score <= 0)
            {
                EndGame(false);
            } else if (_score >= _maxScore)
            {
                EndGame(true);
            }
        }

        private void EndGame(bool state)
        {
            if (state)
            {
                GameOver?.Invoke(true);
                Debug.Log("WOOOOON");
                // Won
            }
            else
            {
                GameOver?.Invoke(false);
                Debug.Log("LOOOST");
                // Lost
            }
        }
        
        private void OnEnable()
        {
            Player.PlayerBallCollision += OnPlayerBallCollision;
        }

        private void OnDisable()
        {
            Player.PlayerBallCollision -= OnPlayerBallCollision;
        }

        private void OnValidate()
        {
            if (_startingScore >= _maxScore) _startingScore = _maxScore - 1;
            if (_maxScore < 2) _maxScore = 2;
        }

        public void EndGameByTimer()
        {
            EndGame(_score > _startingScore);
        }
    }
}