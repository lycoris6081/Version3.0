using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

//�o�{���b�޲z�C�������W�����s
public class SMeneger : MonoBehaviour
{
    public void Play()
    {
        //�i�J���d���
        SceneManager.LoadScene(1);
    }

    public void Introduce()
    {
        //�ާ@����

    }

    public void Setup()
    {
        //�C���]�w
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        //���}�C��
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

    public void back()
    {
        //�^��C������
        SceneManager.LoadScene(0);
    }
    public void enter()
    {
        //�^��C������
        SceneManager.LoadScene(3);
    }
}
