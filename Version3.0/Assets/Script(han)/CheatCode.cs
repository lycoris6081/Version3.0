using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCode : MonoBehaviour
{
    public Text soulCountText; // �i�H���A��UI Text�ե�i��

    public void ResetGame()
    {
        // ���m�F��ƶq
        PlayerPrefs.SetInt("SoulCount", 0);
        PlayerPrefs.Save();

        // ��sUI�����F��ƶq���
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
