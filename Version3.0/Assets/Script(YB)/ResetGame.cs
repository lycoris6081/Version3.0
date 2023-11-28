using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
   public void Resetgame()
    {
        PlayerHP.hp = 2;
        PlayerHP.Isdead = false;
        PlayerHP.gameover = false;
      
        // 重置游戏时间尺度
        Time.timeScale = 1f;
    }
}
