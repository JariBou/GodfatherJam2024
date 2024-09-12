using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    
    public enum GameEventType
    {
        RandomWallRaise
    }

     [Serializable]
    public class GameEvent
    {

        [SerializeField] private GameEventType _gameEventType;
        [SerializeField, Range(0f, 1f)] private float _probability;
        [SerializeField] private float _strength;
        [SerializeField] private float _duration;

        public GameEventType gameEventType => _gameEventType;
        public float probability => _probability;
        public float strength => _strength;
        public float duration => _duration;
    }
    
    public class EventManager : MonoBehaviour
    {
        [SerializeField] private WallManager _wallManager;
        [SerializeField] private SerializedDictionary<int, List<GameEvent>> _events;
        
        private int _lastUpdatedSecond = -1;

        private void OnTimerUpdate(int second)
        {
            if (second == _lastUpdatedSecond) return;
            _lastUpdatedSecond = second;

            Debug.Log($"Checking events for {second}s");
            if (!_events.TryGetValue(second, out List<GameEvent> events)) return;
            
            
            foreach (GameEvent gameEvent in events)
            {
                if (Random.Range(0f, 1f) > gameEvent.probability) return;

                switch (gameEvent.gameEventType)
                {
                    case GameEventType.RandomWallRaise:
                        _wallManager.ActivateRandomWall();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
        }
        
        private void OnEnable()
        {
            Timer.TimerUpdate += OnTimerUpdate;
        }
        private void OnDisable()
        {
            Timer.TimerUpdate -= OnTimerUpdate;
        }
        
    }
}