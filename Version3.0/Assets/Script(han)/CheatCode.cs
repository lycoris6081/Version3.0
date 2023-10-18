using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCode : MonoBehaviour
{
    public Text soulCountText; // ╈UI Text舱ン秈ㄓ

    public void ResetGame()
    {
        // 竚艶活计秖
        PlayerPrefs.SetInt("SoulCount", 0);
        PlayerPrefs.Save();

        // 穝UIい艶活计秖陪ボ
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
