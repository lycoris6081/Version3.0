using UnityEngine;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    public TextMeshProUGUI textToHide;

    // 在Unity Inspector中將按鈕物件拖放到這個變數中
    public UnityEngine.UI.Button yourButton;

    private void Start()
    {
        // 確保按鈕物件已設置，然後訂閱按下事件
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(HideText);
        }
        else
        {
            Debug.LogError("請在Inspector中指定按鈕物件!");
        }
    }

    void HideText()
    {
        // 檢查TextMeshPro元件是否存在
        if (textToHide != null)
        {
            // 關閉TextMeshPro元件
            textToHide.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("請在Inspector中指定TextMeshPro元件!");
        }
    }
}

