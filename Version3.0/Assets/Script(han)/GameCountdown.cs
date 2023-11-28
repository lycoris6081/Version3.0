using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameCountdown : MonoBehaviour
{
    public TMP_Text countdownText;

    void Start()
    {
        // �b�}�l�ɱҰʭ˼ƨ�{
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {

        // �Ȱ��C���ʧ@
        Time.timeScale = 0f;

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f); // �ϥ�WaitForSecondsRealtime�H����Time.timeScale
        }

        countdownText.text = "Meow!";
        yield return new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(false);

        // ��_�C���ʧ@
        Time.timeScale = 1f;
    }
}
