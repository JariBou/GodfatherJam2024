using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    public class WallManager : MonoBehaviour
    {
        [SerializeField] private List<Wall> _walls;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

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
    }
}
