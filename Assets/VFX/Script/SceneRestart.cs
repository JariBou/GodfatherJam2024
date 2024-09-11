using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
   
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKey(KeyCode.F5))
        {
            SceneManager.LoadScene("Scene_tome");
        }
    }
}
