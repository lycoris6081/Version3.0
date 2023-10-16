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




        private void Start()
        {
            PrepareUI();
            //inventoryData.Initialize();
        }

        private void PrepareUI()
        {
            inventoryUI.InitializeInventoryUI(inventoryData.Size);
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

        }

        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {

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