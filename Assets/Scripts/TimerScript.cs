using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    private float currentTime = 1f;
    private bool timerRunning = false;

    void Update()
    {
        if (timerRunning)
        {
            if (currentTime <= 60)
            {
                currentTime += Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                currentTime = 60;
                // timerText.text = "Passed!";
                timerRunning = false; // Stop updating the timer
                currentTime = 1;
            }
        }
    }


    public void ToggleTimer()
    {
        timerRunning = !timerRunning;
        if (!timerRunning)
        {
            currentTime = 1;
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = currentTime.ToString("0");
    }
}
