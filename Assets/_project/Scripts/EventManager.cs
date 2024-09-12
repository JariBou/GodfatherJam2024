using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace _project.Scripts
{
    public enum GameEvent
    {
        RandomWallRaise
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
                switch (gameEvent)
                {
                    case GameEvent.RandomWallRaise:
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