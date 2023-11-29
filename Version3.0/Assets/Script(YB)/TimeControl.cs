using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    // 宣告按鈕變數
    public Button resumeButton;

    // 開始函數
    void Start()
    {
        // 設定按鈕的點擊事件
        resumeButton.onClick.AddListener(ResumeGame);
    }

    // 恢復遊戲時間的函數
    void ResumeGame()
    {
        // 恢復遊戲時間，將時間流逝速度設置為1
        Time.timeScale = 1;
    }
}
