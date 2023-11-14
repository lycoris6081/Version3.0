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
        // ��l�]�m�A�u��ܲĤ@�i�Ϥ�
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
    }

    // �����ܲĤ@�i�Ϥ�
    public void OnButton1Click()
    {
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
    }

    // �����ܲĤG�i�Ϥ�
    public void OnButton2Click()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(true);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
    }

    // �����ܲĤT�i�Ϥ�
    public void OnButton3Click()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(true);
        image4.gameObject.SetActive(false);
    }

    // �����ܲĥ|�i�Ϥ�
    public void OnButton4Click()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(true);
    }
}

