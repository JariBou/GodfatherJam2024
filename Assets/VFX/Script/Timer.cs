using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer = 180;
    private bool timeIsRunning;
    [SerializeField] private TMP_Text _timeScore;
    private void Start()
    {
        timer = 180;
        timeIsRunning = true;
    }

    private void Update()
    {
        if (timeIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                _timeScore.text = Mathf.Round(timer).ToString();
            }
            else
            {
                timer = 0;
                _timeScore.text = timer.ToString();
                timeIsRunning = false;
                Debug.Log("c'est finis frr");
            }
        }
        
    }
}
