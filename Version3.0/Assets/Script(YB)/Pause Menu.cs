using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHidePanel : MonoBehaviour
{
    public GameObject panelToToggle; // �ޥΧA�Q�n���/���ê�Panel
    private bool isGamePaused = false;

    void Start()
    {
        // �T�O�b�C���}�l�ɱNPanel����
        if (panelToToggle != null)
        {
            panelToToggle.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel(); // ���UESC��ɽե�TogglePanel���
        }

        // �b���U���N���s�ɫ�_�C���ɶ�
        if (isGamePaused && Input.anyKeyDown)
        {
            ResumeGame();
        }
    }

    void TogglePanel()
    {
        if (panelToToggle != null)
        {
            // ������LCanvas�MPanel
            Canvas[] allCanvases = FindObjectsOfType<Canvas>();
            foreach (Canvas canvas in allCanvases)
            {
                if (canvas != null && canvas != panelToToggle.GetComponentInParent<Canvas>())
                {
                    canvas.gameObject.SetActive(false);
                }
            }

            // ����Panel����ܪ��A
            panelToToggle.SetActive(!panelToToggle.activeSelf);

            // �ھ�Panel����ܪ��A�Ȱ�/��_�C���ɶ�
            if (panelToToggle.activeSelf)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // �Ȱ��C���ɶ�
        isGamePaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // ��_�C���ɶ�
        isGamePaused = false;
    }
}
