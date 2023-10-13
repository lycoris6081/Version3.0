using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image imageToChange; // 你需要在Unity编辑器中将你的Image组件分配给这个变量
    public Image newImage;      // 新的Image组件

    public void ChangeImageOnClick()
    {
        if (imageToChange != null && newImage != null)
        {
            imageToChange.sprite = newImage.sprite;
        }
    }
}

