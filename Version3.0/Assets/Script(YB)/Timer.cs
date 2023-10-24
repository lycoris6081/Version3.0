using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    private bool timing = false;

    public Text timerText; // ¤Þ¥ÎUI Text¤¸¯À

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (timing)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void StartTimer()
    {
        elapsedTime = 0.0f;
        timing = true;
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = elapsedTime.ToString("F2") + " ¬í";
        }
    }
}

