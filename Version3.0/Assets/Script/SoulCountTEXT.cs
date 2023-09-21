using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulCountTEXT : MonoBehaviour
{
    public Text soulCountText; // 将 UI Text 组件拖放到这个字段中
    private int soulCount = 0; // 用於追蹤踪灵魂数量
    void Start()
    {
        UpdateSoulCountText();
    }

    void UpdateSoulCountText() 
    {
        soulCountText.text = "Souls: " + soulCount.ToString();
    }
    public void CollectSoul()
    {
        // 收集靈魂邏輯
        soulCount++;
        UpdateSoulCountText();
    }
   
}
