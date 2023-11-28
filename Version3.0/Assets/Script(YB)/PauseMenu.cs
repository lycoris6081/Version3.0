using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to use Unity UI components

public class PauseMenu : MonoBehaviour
{
    public GameObject panelToToggle; // Reference to the panel you want to show/hide
    public bool isGamePaused = false;
    public AbilityControl abilityControl;
    public Button resumeButton; // Reference to the UI button for resuming the game

    void Start()
    {
        // Make sure to hide the panel when the game starts
        if (panelToToggle != null)
        {
            panelToToggle.SetActive(false);
        }

        // Add a listener to the button to call the ResumeGameOnClick function when clicked
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeGameOnClick);
            resumeButton.gameObject.SetActive(false); // Hide the button initially
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel(); // Call TogglePanel function when the ESC key is pressed
        }
    }

    void TogglePanel()
    {
        if (panelToToggle != null)
        {
            Debug.Log("TogglePanel() called");

            // Toggle the display state of the panel
            panelToToggle.SetActive(!panelToToggle.activeSelf);
            Debug.Log("Panel is active: " + panelToToggle.activeSelf);

            // Depending on the panel's display state, pause or resume the game
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
        Time.timeScale = 0f; // Pause the game
        isGamePaused = true;

        if (resumeButton != null)
        {
            resumeButton.gameObject.SetActive(true); // Show the resume button
        }
    }

    void ResumeGame()
    {
        Debug.Log("ResumeGame() called");
        Time.timeScale = 1f; // Resume the game
        isGamePaused = false;

        if (resumeButton != null)
        {
            resumeButton.gameObject.SetActive(false); // Hide the resume button
        }
    }

    // Function to be called when the resume button is clicked
    void ResumeGameOnClick()
    {
        TogglePanel(); // Toggle the panel when the resume button is clicked
    }
}

