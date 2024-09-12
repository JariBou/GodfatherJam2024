using System;
using UnityEngine;

namespace _project.Scripts
{
    public class Wall : MonoBehaviour
    {
        public enum Type {
            Red, Blue, Yellow, Bouncy
        }

        [SerializeField] private Wall.Type _wallType;

        private bool _isActivated = true;

        public Type WallType => _wallType;
        public bool IsInactive => !_isActivated;

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.GetComponent<Ball>() || !_isActivated) return; // TEMP "!_isActivated"
        
            Ball ballScript = other.gameObject.GetComponent<Ball>();
            if (ballScript.BallType == Ball.Type.Master) return;

            switch (WallType)
            {
                case Type.Red or Type.Blue or Type.Yellow:
                    ballScript.DestroyBall();
                    break;
                case Type.Bouncy:
                    Vector3 newBallDir = Vector3.Reflect(ballScript.Dir, other.GetContact(0).normal);
                    ballScript.UpdateDir(newBallDir);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Activate()
        {
            if (_wallType == Type.Bouncy)
            {
                _isActivated = true;
                return;
            }
            float height = GetComponent<MeshRenderer>().bounds.extents.y * 2;
            transform.position += new Vector3(0, height, 0);
            _isActivated = true;
            //TODO + animation and stuff
        }

        public void Deactivate()
        {
            if (_wallType == Type.Bouncy)
            {
                _isActivated = false;
                return;
            }
            float height = GetComponent<MeshRenderer>().bounds.extents.y * 2;
            transform.position -= new Vector3(0, height, 0);
            _isActivated = false;
            //TODO + animation and stuff
        }

        public void SwitchState()
        {
            if (_isActivated) Deactivate();
            else Activate();
        }

        // ====================== TEMP ======================
        private void OnValidate()
        {
            switch (_wallType)
            {
                case Type.Red:
                    GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
                    break;
                case Type.Blue:
                    GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;
                    break;
                case Type.Yellow:
                    GetComponent<MeshRenderer>().sharedMaterial.color = Color.yellow;
                    break;
                case Type.Bouncy:
                    GetComponent<MeshRenderer>().sharedMaterial.color = Color.gray;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
