using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField]
        private UIInventoryItem itemPrefab;

        [SerializeField]
        private RectTransform contentPanel;

        [SerializeField]
        private UIInventoryDescription itemDescription;

        [SerializeField]
        private MouseFollower mouseFollower;

        List<UIInventoryItem> ListofUIItems = new List<UIInventoryItem>();

        private int currentlyDraggedItemIndex = -1;
        public event Action<int> OnDescriptionRequested,
                   OnItemActionRequested,
                   OnStartDragging;

        public event Action<int, int> OnSwapItems;

        private void Awake()
        {
            Hide();
            mouseFollower.Toggle(false);
            itemDescription.ResetDescription();
        }

        public void InitializeInventoryUI(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                UIInventoryItem uiItem =
                      Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
                ListofUIItems.Add(uiItem);
                uiItem.OnItemClicked += HandledItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemDroppedON += HandleSwap;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnRightMouseBtnClick += HandleShowItemActions;
            }


        }

        internal void updateDescription(int itemIndex, Sprite itemImage, string name, string description)
        {
            itemDescription.SetDescription(itemImage, name, description);
            DeselectALLItems();
            ListofUIItems[itemIndex].Select();
        }

        public void UpdateData(int itemIndex,
            Sprite itemImage, int itemQuantity)
        {
            if (ListofUIItems.Count > itemIndex)
            {
                ListofUIItems[itemIndex].SetData(itemImage, itemQuantity);
            }
        }

        private void HandledItemSelection(UIInventoryItem inventoryItemUI)
        {
            Debug.Log(inventoryItemUI.name);
            int index = ListofUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            OnDescriptionRequested?.Invoke(index);
        }

        private void HandleShowItemActions(UIInventoryItem inventoryItemUI)
        {

        }

        private void HandleEndDrag(UIInventoryItem inventoryItemUI)
        {
            ResetDraggtedItem();
        }

        private void HandleSwap(UIInventoryItem inventoryItemUI)
        {
            int index = ListofUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }
            OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
            HandledItemSelection(inventoryItemUI);
        }

        private void ResetDraggtedItem()
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;

        }

        private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
        {
            int index = ListofUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            currentlyDraggedItemIndex = index;
            HandledItemSelection(inventoryItemUI);
            OnStartDragging?.Invoke(index);
        }

        public void CreateDraggedItem(Sprite sprite, int quantity)
        {
            mouseFollower.Toggle(true);
            mouseFollower.SetData(sprite, quantity);
        }



        public void Show()
        {
            gameObject.SetActive(true);
            itemDescription.ResetDescription();
            Reselection();
        }

        public void Reselection()
        {
            itemDescription.ResetDescription();
            DeselectALLItems();
        }

        private void DeselectALLItems()
        {
            foreach (UIInventoryItem item in ListofUIItems)
            {
                item.Deselect();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            ResetDraggtedItem();
        }

        internal void ResetALLItems()
        {
            foreach (var item in ListofUIItems)
            {
                item.ResetData();
                item.Deselect();
            }
        }
    }
}