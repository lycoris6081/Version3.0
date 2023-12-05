using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCountdown : MonoBehaviour
{
    public TMP_Text countdownText;
    public GameObject[] images; // Put your nine images here
    public GameObject panel;

    void Start()
    {
        // �b�}�l�ɱҰʭ˼ƨ�{
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        // ���񧹹Ϥ�
        yield return StartCoroutine(HideImages());

        // �Ȱ��C���ʧ@
        Time.timeScale = 0f;

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f); // �ϥ� WaitForSecondsRealtime �H���� Time.timeScale
        }

        countdownText.text = "Meow!";
        yield return new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(false);

        // ��_�C���ʧ@
        Time.timeScale = 1f;
    }

    IEnumerator HideImages()
    {
        // ����0.5��
        yield return new WaitForSeconds(0.5f);

        

        // �̦����èC�i�Ϥ�
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }

        // ����0.5��
        yield return new WaitForSeconds(0.5f);

        // ���� Panel
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
