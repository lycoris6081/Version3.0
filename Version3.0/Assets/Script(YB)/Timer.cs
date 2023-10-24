using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    private bool timing = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (timing)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "已過時間: " + elapsedTime.ToString("F2") + " 秒");
    }

    void StartTimer()
    {
        elapsedTime = 0.0f;
        timing = true;
    }
}
