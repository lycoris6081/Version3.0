using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // 在Unity??器中?要控制的Panel拖拽到??字段
    public Button showButton; // 在Unity??器中?触??示操作的按?拖拽到??字段

    private bool isPanelVisible = false;

    private void Start()
    {
        // 初始化按?的??事件
        showButton.onClick.AddListener(TogglePanelVisibility);
    }

    private void TogglePanelVisibility()
    {
        // 切?Panel的可?性
        isPanelVisible = !isPanelVisible;
        panel.SetActive(isPanelVisible);
    }
}

