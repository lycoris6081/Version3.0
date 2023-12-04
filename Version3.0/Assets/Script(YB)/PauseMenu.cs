using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelToToggle;
    public bool isGamePaused = false;
    public AbilityControl abilityControl;
    public Button resumeButton;
    public Canvas myCanvas; // Declare a Canvas variable

    void Start()
    {
        if (panelToToggle != null)
        {
            panelToToggle.SetActive(false);
        }

        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeGameOnClick);
            resumeButton.gameObject.SetActive(false);
        }

        if (myCanvas != null)
        {
            myCanvas.enabled = true; // Set the canvas to be initially visible
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }
    }

    void TogglePanel()
    {
        if (panelToToggle != null)
        {
            Debug.Log("TogglePanel() called");

            panelToToggle.SetActive(!panelToToggle.activeSelf);
            Debug.Log("Panel is active: " + panelToToggle.activeSelf);

            // Toggle the canvas visibility based on the panel's state
            if (panelToToggle.activeSelf)
            {
                PauseGame();
                ToggleCanvasVisibility(false);
            }
            else
            {
                ResumeGame();
                ToggleCanvasVisibility(true);
            }
        }
    }

    void PauseGame()
    {
        Debug.Log("PauseGame() called");
        Time.timeScale = 0f;
        isGamePaused = true;

        // 隐藏能力图标
        abilityControl.HideAbilityIconsOnPause();

        if (resumeButton != null)
        {
            resumeButton.gameObject.SetActive(true);
        }
    }

    void ResumeGame()
    {
        Debug.Log("ResumeGame() called");
        Time.timeScale = 1f;
        isGamePaused = false;

        // 显示能力图标
        abilityControl.ShowAbilityIconsOnResume();

        if (resumeButton != null)
        {
            resumeButton.gameObject.SetActive(false);
        }
    }

    void ToggleCanvasVisibility(bool isVisible)
    {
        if (myCanvas != null)
        {
            myCanvas.enabled = isVisible;
        }
    }

    void ResumeGameOnClick()
    {
        TogglePanel();
    }
}
