using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using VFX.Script;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    public class WallManager : MonoBehaviour
    {
        [SerializeField] private List<Wall> _walls;
        [SerializeField] private float _timeBetweenWalls = 5f;
        [SerializeField] private float _delayBeforeStart = 2f;
        private float _lastBuildWallSecond; // 2s of delay before starting walls

        private void Awake()
        {
            _lastBuildWallSecond = _delayBeforeStart;
        }

        private void Start()
        {
            DeactivateAllWalls();
        }

        private void OnTimerUpdated(int obj)
        {
            if (obj - _lastBuildWallSecond >= _timeBetweenWalls)
            {
                ActivateRandomWall();
                _lastBuildWallSecond = obj;
            }
        }

        #region Wall Activation/Deactivation

        public void ActivateRandomWallFromType(Wall.Type wallType)
        {
            List<Wall> wallTypes = _walls.Where(wall => wall.WallType == wallType && wall.IsInactive).ToList();
            if (!wallTypes.Any()) return;
            wallTypes[Random.Range(0, wallTypes.Count)].Activate();
        }

        public void DeactivateAllWallsFromType(Wall.Type wallType)
        {
            foreach (Wall wall in _walls.Where(wall => wall.WallType == wallType && !wall.IsInactive).ToList())
            {
                wall.Deactivate();
            }
        }
        
        public void ActivateAllWallsFromType(Wall.Type wallType)
        {
            foreach (Wall wall in _walls.Where(wall => wall.WallType == wallType && wall.IsInactive).ToList())
            {
                wall.Activate();
            }
        }

        [SerializeField] private Wall.Type _wallType;
        [Button]
        public void TestFunc()
        {
            ActivateRandomWallFromType(_wallType);
        }

        public void ActivateRandomWall()
        {
            List<Wall> inactiveWalls = _walls.Where(wall => wall.IsInactive).ToList();
            if (!inactiveWalls.Any()) return;
            inactiveWalls[Random.Range(0, inactiveWalls.Count)].Activate();
        }

        public void ActivateAllWalls()
        {
            ActivateAllWallsFromType(Wall.Type.Red);
            ActivateAllWallsFromType(Wall.Type.Blue);
            ActivateAllWallsFromType(Wall.Type.Yellow);
        }
        
        public void DeactivateAllWalls()
        {
            DeactivateAllWallsFromType(Wall.Type.Red);
            DeactivateAllWallsFromType(Wall.Type.Blue);
            DeactivateAllWallsFromType(Wall.Type.Yellow);
        }

        #endregion
        
        private void OnEnable()
        {
            Timer.TimerUpdate += OnTimerUpdated;
        }

        private void OnDisable()
        {
            Timer.TimerUpdate -= OnTimerUpdated;
        }
        
    }
}
