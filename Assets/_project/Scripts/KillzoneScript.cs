using UnityEngine;

namespace _project.Scripts
{
    public class KillzoneScript : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Ball>())
            {
                Ball ballScript = other.gameObject.GetComponent<Ball>();
                ballScript.DestroyBall();
            } else if (other.gameObject.GetComponent<Player>())
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.Respawn();
            }
        }
    }
}
