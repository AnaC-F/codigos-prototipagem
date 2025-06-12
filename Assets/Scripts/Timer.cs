using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 300f;
    public TextMeshProUGUI timerText;

    private bool _isRunning = true;

    void Update()
    {
        if (!_isRunning) return;
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            _isRunning = false;
            TimerEnded();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void TimerEnded()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
