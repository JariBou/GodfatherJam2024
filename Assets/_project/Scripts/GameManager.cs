using System;
using UnityEngine;

namespace _project.Scripts
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private int _maxScore = 100;
        [SerializeField] private int _startingScore = 50;
        [SerializeField] private VFXManager _vfxManager;

        private int _score;

        private void Awake()
        {
            _score = _startingScore;
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
            // TODO
            // Check win con and update displays
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
    }
}