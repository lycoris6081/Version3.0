using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCountdown : MonoBehaviour
{
    public TMP_Text countdownText;
    public GameObject[] images; // Put your nine images here
    public GameObject panel;

    void Start()
    {
        // 在開始時啟動倒數協程
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        // 播放完圖片
        yield return StartCoroutine(HideImages());

        // 暫停遊戲動作
        Time.timeScale = 0f;

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f); // 使用 WaitForSecondsRealtime 以忽略 Time.timeScale
        }

        countdownText.text = "Meow!";
        yield return new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(false);

        // 恢復遊戲動作
        Time.timeScale = 1f;
    }

    IEnumerator HideImages()
    {
        // 延遲0.5秒
        yield return new WaitForSeconds(0.5f);

        

        // 依次隱藏每張圖片
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }

        // 延遲0.5秒
        yield return new WaitForSeconds(0.5f);

        // 關閉 Panel
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
