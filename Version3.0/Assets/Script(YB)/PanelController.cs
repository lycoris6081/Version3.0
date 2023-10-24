using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // 在Unity编辑器中要控制的Panel拖拽到该字段
    public Button showButton; // 在Unity编辑器中触发显示操作的按钮拖拽到该字段

    private bool isPanelVisible = false;

    private void Start()
    {
        // 初始化按钮的点击事件
        showButton.onClick.AddListener(TogglePanelVisibility);
    }

    private void TogglePanelVisibility()
    {
        // 切换Panel的可见性
        isPanelVisible = !isPanelVisible;
        panel.SetActive(isPanelVisible);

        // 根据Panel的可见性设置游戏时间
        if (isPanelVisible)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // 暂停游戏时间
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // 恢复游戏时间
    }
}


