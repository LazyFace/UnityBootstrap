using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float timer = 0;
    private bool isTimerRunning = false;

    public PlatformTriggerScript startPlatform;
    public PlatformTriggerScript endPlatform;

    public TextMeshProUGUI timerText;

    public bool isTimerSet = false;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (isTimerRunning && isTimerSet)
        {
            timer += Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (isTimerSet && !startPlatform.PlayerInsideZone())
        {
            StartTimer();
        }
        if (isTimerRunning && endPlatform.PlayerInsideZone())
        {
            StopTimer();
        }
        if (!isTimerSet && startPlatform.PlayerInsideZone())
        {
            ResetTimer();
        }

        UpdateUI(formattedTime);
    }

    public void UpdateUI(string time)
    {
        timerText.text = time;
    }

    public void ResetTimer()
    {
        timer = 0;
        isTimerSet = true;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        isTimerSet = false;
    }

    public float CurrentTimer()
    {
        return timer;
    }
}
