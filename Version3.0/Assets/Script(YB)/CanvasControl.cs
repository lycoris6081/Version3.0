using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public GameObject canvasToToggle; // 引用第二个Canvas

    void Start()
    {
        canvasToToggle.SetActive(false); // 初始时将第二个Canvas设置为不可见
    }

    public void ToggleCanvas()
    {
        canvasToToggle.SetActive(!canvasToToggle.activeSelf); // 切换第二个Canvas的可见性
    }
}

