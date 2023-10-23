using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Image[] images;

    private int currentImageIndex = -1;

    private void Start()
    {
        HideAllImages();
    }

    public void ShowImage(int imageIndex)
    {
        HideCurrentImage();

        if (imageIndex >= 0 && imageIndex < images.Length)
        {
            images[imageIndex].enabled = true;
            currentImageIndex = imageIndex;
        }
    }

    public void HideCurrentImage()
    {
        if (currentImageIndex >= 0 && currentImageIndex < images.Length)
        {
            images[currentImageIndex].enabled = false;
        }
    }

    public void HideAllImages()
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }
        currentImageIndex = -1;
    }
}
