using UnityEngine;
using UnityEngine.SceneManagement;

namespace VFX.Script
{
    public class SceneHandler : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
