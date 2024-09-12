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

        [SerializeField] private Wall.Type _wallType;
        [Button]
        public void TestFunc()
        {
            ActivateRandomWallFromType(_wallType);
        }
        
    }
}
