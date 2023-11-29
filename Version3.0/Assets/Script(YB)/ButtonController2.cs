using UnityEngine;
using UnityEngine.UI;

public class ButtonController2 : MonoBehaviour
{
    [Header("控制切換小關卡詳細內容")]
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5; // Add new image
    public Image image6; // Add new image

    // Start is called before the first frame update
    void Start()
    {
        // Initial setup, only show the first image
        SetActiveImage(image1);
    }

    // Select to show the first image
    public void OnButton1Click()
    {
        SetActiveImage(image1);
    }

    // Select to show the second image
    public void OnButton2Click()
    {
        SetActiveImage(image2);
    }

    // Select to show the third image
    public void OnButton3Click()
    {
        SetActiveImage(image3);
    }

    // Select to show the fourth image
    public void OnButton4Click()
    {
        SetActiveImage(image4);
    }

    // Select to show the fifth image
    public void OnButton5Click()
    {
        SetActiveImage(image5);
    }

    // Select to show the sixth image
    public void OnButton6Click()
    {
        SetActiveImage(image6);
    }

    // Helper method to set only the selected image active
    private void SetActiveImage(Image activeImage)
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
        image5.gameObject.SetActive(false);
        image6.gameObject.SetActive(false);

        activeImage.gameObject.SetActive(true);
    }
}
