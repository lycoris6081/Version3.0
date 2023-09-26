using UnityEngine;
using UnityEngine.UI;

public class CanvasControl2 : MonoBehaviour
{
    public GameObject canvasToToggle; // 引用需要关闭的Canvas

    public void CloseCanvas()
    {
        canvasToToggle.SetActive(false); // 关闭Canvas，将其设置为不可见
    }
}

