using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public TextMeshProUGUI soulCountText; // 将 UI Text 组件拖放到这个字段中

    private void Start()
    {
        // 当游戏菜单打开时，从PlayerPrefs加载灵魂数量
        LoadSoulCount();
        UpdateSoulCountText();
    }

    public void UpdateSoulCountText()
    {
        int soulCount = GetSoulCount();
        soulCountText.text = soulCount + " / "+"10";
    }

    public int GetSoulCount()
    {
        return PlayerPrefs.GetInt("SoulCount", 0); // 从PlayerPrefs中获取灵魂数量，如果没有则返回0
    }

    public void ResetSoulCount()
    {
        // 重置灵魂获取量并保存到PlayerPrefs
        PlayerPrefs.SetInt("SoulCount", 0);
        PlayerPrefs.Save();
        UpdateSoulCountText();
    }

    private void LoadSoulCount()
    {
        // 从PlayerPrefs加载灵魂数量
        soulCountText.text = "Soul Count: " + GetSoulCount().ToString();
    }
}
