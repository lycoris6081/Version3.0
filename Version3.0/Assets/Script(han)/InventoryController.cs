using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    public int inventorySize = 10;


    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }

  

    public void InventoryShow()
    {
        inventoryUI.Show();
    }

    
}
