using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCanvasOnButtonClick : MonoBehaviour
{
    public Canvas canvasToHide; // 將Canvas拖放到這個變數中
    public Button hideButton; // 將按鈕拖放到這個變數中

    void Start()
    {
        // 添加按鈕點擊事件監聽器
        hideButton.onClick.AddListener(HideCanvas);
    }

    void HideCanvas()
    {
        // 設置Canvas為不可見
        canvasToHide.enabled = false;
    }
}

