using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulUI : MonoBehaviour
{


    public Image soulUI;
    public Text soulCountText; // 将 UI Text 组件拖放到这个字段中
    private int soulCount = 0; // 用於追蹤踪灵魂数量
    void Start()
    {
       soulUI = GetComponent<Image>();
        UpdateSoulCountText();
    }

    void UpdateSoulCountText() 
    {
        soulCountText.text = soulCount.ToString();
    }

    public void CollectSoul()
    {
        // 收集靈魂邏輯
        soulCount++;
        UpdateSoulCountText();
    }
    public int GetSoulCount()
    {
        return soulCount; // 用於紀錄靈魂数量
    }

    public void ResetSoulCount()
    {
        // 重置灵魂获取量
        soulCount = 0;
        UpdateSoulCountText();
    }
}
