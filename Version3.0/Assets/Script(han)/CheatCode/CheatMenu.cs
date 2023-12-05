using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMenu : MonoBehaviour
{
    public GameObject menuPanel;

    // 遊戲是否被暫停
    private bool isPaused = false;

    // 在遊戲啟動時設定
    void Start()
    {
        // 隱藏選單面板
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    // 更新函式中處理輸入
    void Update()
    {
        // 如果按下數字鍵0，則切換選單的顯示與暫停遊戲
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ToggleMenu();
        }
    }

    // 切換選單的顯示與暫停遊戲
    void ToggleMenu()
    {
        // 切換選單的顯示
        if (menuPanel != null)
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }

        // 切換遊戲的暫停狀態
        isPaused = !isPaused;

        // 根據暫停狀態調整時間尺度
        Time.timeScale = isPaused ? 0 : 1;
    }
}
