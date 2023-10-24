using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private UIInventoryPage inventoryUI;


        [SerializeField]
        private InventorySO inventoryData;

        public List<InventoryItem> inventoryItems = new List<InventoryItem>();

        public ItemSO[]  items;
        public InventorySO[] inventorySO;

        private InventorySO GetInventoryData()
        {
            return inventoryData;
        }

        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItem item in inventoryItems) 
            {
              if(item.IsEmpty)
              
                continue;
                inventoryData.AddItem(item);
              
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetALLItems();
            foreach (var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage,
                    item.Value.quantity);
            }
        }

        private void PrepareUI()
        {
            
            inventoryUI.InitializeInventoryUI(inventoryData.Size);
            inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            inventoryUI.OnSwapItems += HandleSwapItems;
            inventoryUI.OnStartDragging += HandleDragging;
            inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleItemActionRequest(int ItemIndex)
        {

        }

        private void HandleDragging(int ItemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(ItemIndex);
            if (inventoryItem.IsEmpty)
                return;
            inventoryUI.CreateDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity);
        }

        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {
            inventoryData.swapItems(itemIndex_1, itemIndex_2);
        }

        private void HandleDescriptionRequest(int ItemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(ItemIndex);

            if (inventoryItem.IsEmpty)
            {
                inventoryUI.Reselection();
                return;
            }

            ItemSO item = inventoryItem.item;
            inventoryUI.updateDescription(ItemIndex, item.ItemImage,
                item.name, item.Description);


            // 更新TMP字段以显示Cost值
            string costText = "Cost: " + item.Cost.ToString(); // 获取Cost值并转换为字符串
            inventoryUI.UpdateCostText(costText); // 使用此方法更新Cost TMP字段

        }

        public void InventoryShow()
        {
            inventoryUI.Show();
            foreach (var item in inventoryData.GetCurrentInventoryState())
            {
                inventoryUI.UpdateData(item.Key,
                    item.Value.item.ItemImage,
                    item.Value.quantity);
            }
        }

        


       

    }
}