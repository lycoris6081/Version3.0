using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelToToggle; // 引用你想要顯示/隱藏的Panel
    private bool isGamePaused = false;

    void Start()
    {
        // 確保在遊戲開始時將Panel隱藏
        if (panelToToggle != null)
        {
            panelToToggle.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel(); // 按下ESC鍵時調用TogglePanel函數
        }

        // 在按下任意按鈕時恢復遊戲時間
        if (isGamePaused && Input.anyKeyDown)
        {
            ResumeGame();
        }
    }

    void TogglePanel()
    {
        if (panelToToggle != null)
        {
            // 關閉其他Canvas和Panel
            Canvas[] allCanvases = FindObjectsOfType<Canvas>();
            foreach (Canvas canvas in allCanvases)
            {
                if (canvas != null && canvas != panelToToggle.GetComponentInParent<Canvas>())
                {
                    canvas.gameObject.SetActive(false);
                }
            }

            // 反轉Panel的顯示狀態
            panelToToggle.SetActive(!panelToToggle.activeSelf);

            // 根據Panel的顯示狀態暫停/恢復遊戲時間
            if (panelToToggle.activeSelf)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // 暫停遊戲時間
        isGamePaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // 恢復遊戲時間
        isGamePaused = false;
    }
}