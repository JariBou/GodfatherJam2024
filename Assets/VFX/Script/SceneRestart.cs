using UnityEngine;
using UnityEngine.SceneManagement;

namespace VFX.Script
{
    public class SceneRestart : MonoBehaviour
    {
   
        void Update()
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetKey(KeyCode.F5))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
