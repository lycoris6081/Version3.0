using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public TextMeshProUGUI soulCountText; // 将 UI Text 组件拖放到这个字段中
    public ItemSO itemToUnlock; // 将要解锁的物品的 ItemSO，包含 Cost 值
    public Button unlockButton; // 将解锁按钮拖放到这个字段中


    private void Start()
    {
        // 当游戏菜单打开时，从PlayerPrefs加载灵魂数量
        LoadSoulCount();

        // 在启动时检查是否可以解锁
        CheckUnlockConditions();
    }

 

    public int GetSoulCount()
    {
        return PlayerPrefs.GetInt("SoulCount", 0); // 从PlayerPrefs中获取灵魂数量，如果没有则返回0
    }

    public void ResetSoulCount()
    {
        // 不要重置靈魂計數，只需要清除UI顯示
        soulCountText.text = "Soul Count: ";
    }

    private void LoadSoulCount()
    {
        // 从PlayerPrefs加载灵魂数量
        soulCountText.text = "Soul" + GetSoulCount().ToString();
    }

    private void CheckUnlockConditions()
    {
        if (GetSoulCount() >= itemToUnlock.Cost)
        {
            // 如果灵魂数量大于等于要解锁的物品的 Cost 值，启用解锁按钮
            unlockButton.interactable = true;
        }
        else
        {
            // 否则禁用解锁按钮
            unlockButton.interactable = false;
        }
    }

    public void Unlock()
    {
        if (GetSoulCount() >= itemToUnlock.Cost)
        {
            // 如果灵魂数量大于等于要解锁的物品的 Cost 值，执行解锁操作


            // 这里可以添加解锁逻辑，例如减去 Cost，解锁特定功能等
            Debug.Log("Unlocked!");

            // 更新灵魂计数
            PlayerPrefs.SetInt("SoulCount", GetSoulCount() - itemToUnlock.Cost);
            LoadSoulCount();

            // 检查是否可以继续解锁
            CheckUnlockConditions();
        }
    
    }
}
