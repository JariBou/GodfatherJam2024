using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

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

        public void ActivateWallType(Wall.Type wallType)
        {
            foreach (Wall wall in _walls)
            {
                if (wall.WallType == wallType) wall.SwitchState();
                // else wall.Deactivate();
            }
        }

        [SerializeField] private Wall.Type _wallType;
        [Button]
        public void TestFunc()
        {
            ActivateWallType(_wallType);
        }
        
    }
}
