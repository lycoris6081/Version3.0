using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    List<UIInventoryItem> ListofUIItems = new List<UIInventoryItem>();


    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem =
                  Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            ListofUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandledItemSelction;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedON += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }

       
    }

    private void HandleShowItemActions(UIInventoryItem item)
    {
        
    }

    private void HandleEndDrag(UIInventoryItem item)
    {
       
    }

    private void HandleSwap(UIInventoryItem item)
    {
       
    }

    private void HandleBeginDrag(UIInventoryItem item)
    {
       
    }

    private void HandledItemSelction(UIInventoryItem item)
    {
        Debug.Log(item.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
