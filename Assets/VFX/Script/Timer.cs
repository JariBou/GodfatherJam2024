using System;
using System.Collections;
using System.Collections.Generic;
using _project.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _gameTime = 120;
    private float _timer = 120;
    private bool timeIsRunning;
    [SerializeField] private TMP_Text _timeScore;
    [SerializeField] private GameManager _gameManager;

    public static event Action<int> TimerUpdate;
    private void Start()
    {
        _timer = _gameTime;
        timeIsRunning = true;
    }

    private void FixedUpdate()
    {
        if (timeIsRunning)
        {
            if (_timer > 0)
            {
                _timer -= Time.fixedDeltaTime;
                _timeScore.text = Mathf.Round(_timer).ToString();
            }
            else
            {
                _timer = 0;
                _timeScore.text = _timer.ToString();
                timeIsRunning = false;
                _gameManager.EndGameByTimer();
                Debug.Log("c'est finis frr");
            }
            
        }
        
        TimerUpdate?.Invoke(Mathf.FloorToInt(_gameTime - _timer));
    }
    
    private void OnGameOver(bool state)
    {
        timeIsRunning = false;
    }

    private void OnEnable()
    {
        GameManager.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.GameOver -= OnGameOver;
    }
}
