using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class loading2 : MonoBehaviour
{
    public GameObject[] images; // ��m�A���E�i�Ϥ����}�C
    public GameObject panel; // Panel ��H

    void Start()
    {
        // ��l�ơA�N�Ҧ��Ϥ��]�m���i��
        foreach (var image in images)
        {
            image.SetActive(true);
        }

        // �Ұʨ�{�A����0.5���}�l���ùϤ�
        StartCoroutine(HideImages());
    }

    IEnumerator HideImages()
    {
        // ����0.5��
        yield return new WaitForSeconds(0.2f);

        // �̦����èC�i�Ϥ�
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }

        // ����0.5��
        yield return new WaitForSeconds(0.2f);

        // ���� Panel
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}