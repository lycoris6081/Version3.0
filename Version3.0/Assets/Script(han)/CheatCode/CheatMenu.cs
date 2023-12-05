using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMenu : MonoBehaviour
{
    public GameObject menuPanel;

    // �C���O�_�Q�Ȱ�
    private bool isPaused = false;

    // �b�C���Ұʮɳ]�w
    void Start()
    {
        // ���ÿ�歱�O
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    // ��s�禡���B�z��J
    void Update()
    {
        // �p�G���U�Ʀr��0�A�h������檺��ܻP�Ȱ��C��
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ToggleMenu();
        }
    }

    // ������檺��ܻP�Ȱ��C��
    void ToggleMenu()
    {
        // ������檺���
        if (menuPanel != null)
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }

        // �����C�����Ȱ����A
        isPaused = !isPaused;

        // �ھڼȰ����A�վ�ɶ��ث�
        Time.timeScale = isPaused ? 0 : 1;
    }
}
