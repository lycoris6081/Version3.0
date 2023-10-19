using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulUI : MonoBehaviour
{


    public Image soulUI;
    public Text soulCountText; // 将 UI Text 组件拖放到这个字段中
    public static int soulCount = 0; // 用於追蹤踪灵魂数量
    void Start()
    {
        PlayerPrefs.GetInt("SoulCount", 0);
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

        // 将灵魂数量保存到PlayerPrefs
        PlayerPrefs.SetInt("SoulCount", soulCount);
        PlayerPrefs.Save();
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

    public void gameover()
    {

        if (PlayerHP.gameover == true)
        {
            // 載入之前的靈魂數量
            int previousSoulCount = PlayerPrefs.GetInt("SoulCount", 0);

            // 將之前的數量添加到當前的靈魂計數中
            soulCount += previousSoulCount;

            // 将灵魂数量保存到PlayerPrefs
            PlayerPrefs.SetInt("SoulCount", soulCount);
            PlayerPrefs.Save();
        }
       
    }
   

}
