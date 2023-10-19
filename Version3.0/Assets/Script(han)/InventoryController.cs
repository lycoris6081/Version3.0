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

        public ItemSO[] items;
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
            foreach (ItemSO unlockitem in items ) 
            {
                if (unlockitem.Price == 0)
                {

                    unlockitem.IsUnlocked = true;
                }
                else
                {
                    unlockitem.IsUnlocked = PlayerPrefs.GetInt(unlockitem.name, 0) == 0 ? false : true; //等於下面那幾行

                    //if(PlayerPrefs.GetInt(unlockitem.name, 0)==0)
                    //{
                    //    unlockitem.IsUnlocked = false;
                    //}
                    //else
                    //{
                    //    unlockitem.IsUnlocked = true;
                    //}

                }


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