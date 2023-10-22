using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image image; // 引用要显示的图像的Image组件

    // 此方法将在按钮按下时调用
    public void OpenImage()
    {
        if (image != null)
        {
            image.enabled = true; // 启用图像组件以显示图像
        }
    }

    // 此方法将在按钮按下时调用，用于关闭图像
    public void CloseImage()
    {
        if (image != null)
        {
            image.enabled = false; // 禁用图像组件以隐藏图像
        }
    }
}

