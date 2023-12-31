using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCode : MonoBehaviour
{
    public Text soulCountText; // 可以拖放你的UI Text組件進來

    public void ResetGame()
    {
        // 重置靈魂數量
        PlayerPrefs.SetInt("SoulCount", 0);
        PlayerPrefs.Save();

        // 更新UI中的靈魂數量顯示
        UpdateSoulCountText();
    }

    public void UpdateSoulCountText()
    {
        int soulCount = GetSoulCount();
        soulCountText.text = "0";
    }

    public int GetSoulCount()
    {
        return PlayerPrefs.GetInt("SoulCount", 0);
    }
}
