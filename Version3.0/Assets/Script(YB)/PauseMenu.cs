using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelToToggle; // 引用你想要显示/隐藏的Panel
    public  bool isGamePaused = false;
    public AbilityControl abilityControl;

    void Start()
    {
        // 确保在游戏开始时将Panel隐藏
        if (panelToToggle != null)
        {
            panelToToggle.SetActive(false);
        }
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel(); // 按下ESC键时调用TogglePanel函数
        }
    }

    void TogglePanel()
    {
        if (panelToToggle != null)
        {
            Debug.Log("TogglePanel() called");

            // 反转Panel的显示状态
            panelToToggle.SetActive(!panelToToggle.activeSelf);
            Debug.Log("Panel is active: " + panelToToggle.activeSelf);

            // 根据Panel的显示状态暂停/恢复游戏时间
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
        Debug.Log("PauseGame() called");
        Time.timeScale = 0f; // 暂停游戏时间
        isGamePaused = true;
        
        
    }

    void ResumeGame()
    {
        Debug.Log("ResumeGame() called");
        Time.timeScale = 1f; // 恢复游戏时间
        isGamePaused = false;
       
      
    }
}
