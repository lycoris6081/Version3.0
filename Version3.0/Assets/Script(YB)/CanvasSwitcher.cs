using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;

    // 在Start方法中進行初始化
    void Start()
    {
        // 初始設置，canvas1可見，canvas2不可見
        canvas1.enabled = true;
        canvas2.enabled = false;
    }

    // 更新每一幀的狀態
    void Update()
    {
        // 檢查是否按下Escape鍵，如果是，則切換Canvas的可見性
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanvasVisibility();
        }
    }

    // 切換Canvas的可見性
    void ToggleCanvasVisibility()
    {
        // 切換canvas1和canvas2的可見性
        canvas1.enabled = !canvas1.enabled;
        canvas2.enabled = !canvas2.enabled;
    }
}

