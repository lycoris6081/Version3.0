using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UnlockableItem
{
      public ItemSO itemToUnlock;  // 要解锁的道具
      public int unlockCost = 10;  // 解锁所需的靈魂數量

}

public class UnlockItem : MonoBehaviour
{
  public TextMeshProUGUI soulCountText;  // 顯示靈魂數量的UI Text
  public Button unlockButton;  // 解锁按鈕
  public UnlockableItem[] unlockableItems;  // 多个要解锁的道具
  private int currentUnlockIndex = -1;  // 当前选中解锁的道具索引

  private void Start()
  {
        LoadSoulCount();
        unlockButton.interactable = false;
        UpdateSoulCountText();
          
            
  }

        public void SelectItemToUnlock(int index)
        {
            if (index < 0 || index >= unlockableItems.Length)
                return;

            currentUnlockIndex = index;
            UnlockableItem unlockableItem = unlockableItems[currentUnlockIndex];
            unlockButton.interactable = CanUnlockItem(unlockableItem);

           
        }

    public void SetSelectedItem(int selectedIndex)
    {
        currentUnlockIndex = selectedIndex;
    }

    public void UnlockSelectedItem()
    {
        if (currentUnlockIndex < 0 || currentUnlockIndex >= unlockableItems.Length)
            return;

        UnlockableItem unlockableItem = unlockableItems[currentUnlockIndex];
        if (CanUnlockItem(unlockableItem))
        {
            int currentSoulCount = PlayerPrefs.GetInt("SoulCount", 0);

            // 检查靈魂數量是否足够解锁
            if (currentSoulCount >= unlockableItem.unlockCost)
            {
                // 扣除靈魂數量
                currentSoulCount -= unlockableItem.unlockCost;
                PlayerPrefs.SetInt("SoulCount", currentSoulCount);
                PlayerPrefs.Save();

                // 解锁道具（你需要根據你的道具系統進行解锁）
                // unlockableItem.itemToUnlock 可以是一個參考到你的道具系統的物件

                // 更新UI顯示
                UpdateSoulCountText();
            }
        }
    }

        private bool CanUnlockItem(UnlockableItem item)
        {
            int currentSoulCount = PlayerPrefs.GetInt("SoulCount", 0);
            return currentSoulCount >= item.unlockCost;
        }

        private void UpdateSoulCountText()
        {
         int currentSoulCount = PlayerPrefs.GetInt("SoulCount", 0);
         UnlockableItem unlockableItem = unlockableItems[currentUnlockIndex];
         soulCountText.text = $"{currentSoulCount} / {unlockableItem.unlockCost}";
        }

        public int GetSoulCount()
        {
         return PlayerPrefs.GetInt("SoulCount", 0); // 从PlayerPrefs中获取灵魂数量，如果没有则返回0
        }

        public void ResetSoulCount()
        {
        // 不要重置靈魂計數，只需要清除UI顯示
          int unlockCost = unlockableItems[currentUnlockIndex].unlockCost;
         soulCountText.text = "Soul Count: 0 / " + unlockCost;
        }

        private void LoadSoulCount()
        {
        // 从PlayerPrefs加载灵魂数量
        soulCountText.text =  GetSoulCount().ToString();
        }   

}
