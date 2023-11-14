using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextButtonController : MonoBehaviour
{
    public TextMeshProUGUI[] texts; // 連結到七個 TextMeshProUGUI
    public Button[] buttons; // 連結到七個按鈕

    void Start()
    {
        // 確保 texts 和 buttons 長度相等
        if (texts.Length != buttons.Length)
        {
            Debug.LogError("texts 和 buttons 的數量應該相等！");
            return;
        }

        // 初始化設置，確保只有 Text1 顯示，其他 Text 關閉
        for (int i = 1; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(false);
        }

        // 添加按鈕點擊事件
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // 為了在按鈕點擊事件中使用正確的索引
            buttons[i].onClick.AddListener(() => SwitchText(index));
        }
    }

    void SwitchText(int activeIndex)
    {
        // 遍歷所有 Text，只有 activeIndex 的 Text 顯示，其他 Text 關閉
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(i == activeIndex);
        }
    }
}
