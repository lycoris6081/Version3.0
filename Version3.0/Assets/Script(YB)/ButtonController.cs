using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

    // Start is called before the first frame update
    void Start()
    {
        // 初始設置，只顯示第一張圖片
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
    }

    // 選擇顯示第一張圖片
    public void OnButton1Click()
    {
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
    }

    // 選擇顯示第二張圖片
    public void OnButton2Click()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(true);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
    }

    // 選擇顯示第三張圖片
    public void OnButton3Click()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(true);
        image4.gameObject.SetActive(false);
    }

    // 選擇顯示第四張圖片
    public void OnButton4Click()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(true);
    }
}

