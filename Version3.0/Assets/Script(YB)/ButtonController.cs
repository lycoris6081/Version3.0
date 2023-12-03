using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [Header("��������j���d�ԲӤ��e")]
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

    [Header("�w�]��ܪ��Ϥ�")]
    [SerializeField]
    private int defaultImageIndex = 1; // Default to the first image

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultImage();
    }

    // Set the default image based on the specified index
    void SetDefaultImage()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);

        switch (defaultImageIndex)
        {
            case 1:
                image1.gameObject.SetActive(true);
                break;
            case 2:
                image2.gameObject.SetActive(true);
                break;
            case 3:
                image3.gameObject.SetActive(true);
                break;
            case 4:
                image4.gameObject.SetActive(true);
                break;
            default:
                Debug.LogWarning("Invalid defaultImageIndex. Defaulting to the first image.");
                image1.gameObject.SetActive(true);
                break;
        }
    }

    // �����ܲĤ@�i�Ϥ�
    public void OnButton1Click()
    {
        SetImagesActiveState(true, false, false, false);
    }

    // �����ܲĤG�i�Ϥ�
    public void OnButton2Click()
    {
        SetImagesActiveState(false, true, false, false);
    }

    // �����ܲĤT�i�Ϥ�
    public void OnButton3Click()
    {
        SetImagesActiveState(false, false, true, false);
    }

    // �����ܲĥ|�i�Ϥ�
    public void OnButton4Click()
    {
        SetImagesActiveState(false, false, false, true);
    }

    // Helper method to set the active state of images
    void SetImagesActiveState(bool active1, bool active2, bool active3, bool active4)
    {
        image1.gameObject.SetActive(active1);
        image2.gameObject.SetActive(active2);
        image3.gameObject.SetActive(active3);
        image4.gameObject.SetActive(active4);
    }
}


