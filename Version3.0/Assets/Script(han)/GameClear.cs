using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public GameObject gameClearCanvas;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CATCAT")
        {
            if (gameClearCanvas != null)
            {
                gameClearCanvas.SetActive(true);
                PauseGame();
                
                
            }
        }
    }

    private void PauseGame()
    {
        // Pause the game by setting the time scale to 0
        Time.timeScale = 0f;
    }
}


