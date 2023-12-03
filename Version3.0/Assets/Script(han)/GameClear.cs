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
            }
        }
    }
}

