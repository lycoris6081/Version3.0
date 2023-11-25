using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    public bool timing = false;

    //private bool isRunning = false;
    public float startTime;
    public float countTime;
    public float int_mins;
    public float int_secs;

    public TextMeshProUGUI Text_Time;

    public TextMeshProUGUI Gameover_text;
    public TextMeshProUGUI inGameDebug_text;
    public TextMeshProUGUI Pass_text;
    public TextMeshProUGUI Pause_text;
    //public Text timerText; // ¤Þ¥ÎUI Text¤¸¯À

    void Start()
    {
        StartTimer();
        startTime = Time.time;
        countTime = 0;
    }

    void Update()
    {
        
        Fly_CountTime();
        showTime();
        /*
        if (timing)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }*/
    }

    void StartTimer()
    {
        elapsedTime = 0.0f;
        timing = true;
    }

    void UpdateTimerText()
    {
        if (Text_Time != null)
        {
            Text_Time.text = elapsedTime.ToString("F2") + "¬í";
        }
    }

    public void Fly_CountTime()
    {
        countTime = Time.time;

        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isRunning = false;
        }*/

        float gameDuration = countTime - startTime;

        int_mins = Mathf.FloorToInt(gameDuration / 60);
        int_secs = Mathf.FloorToInt(gameDuration % 60);

    }

    void showTime()
    {

        if (int_secs <= 9)
            Gameover_text.text = int_mins + ":0" + int_secs;
        else
            Gameover_text.text = int_mins + ":" + int_secs;

        if (int_secs <= 9)
            inGameDebug_text.text = int_mins + ":0" + int_secs;
        else
            inGameDebug_text.text = int_mins + ":" + int_secs;

        if (int_secs <= 9)
            Pass_text.text = int_mins + ":0" + int_secs;
        else
            Pass_text.text = int_mins + ":" + int_secs;

        if (int_secs <= 9)
            Pause_text.text = int_mins + ":0" + int_secs;
        else
            Pause_text.text = int_mins + ":" + int_secs;
    }

}

