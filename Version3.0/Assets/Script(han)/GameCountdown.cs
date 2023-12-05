using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameCountdown : MonoBehaviour
{
    public TMP_Text countdownText;

    void Start()
    {
        // 在開始時啟動倒數協程
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {

        // 暫停遊戲動作
        Time.timeScale = 0f;

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f); // 使用WaitForSecondsRealtime以忽略Time.timeScale
        }

        countdownText.text = "Meow!";
        yield return new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(false);

        // 恢復遊戲動作
        Time.timeScale = 1f;
    }
}