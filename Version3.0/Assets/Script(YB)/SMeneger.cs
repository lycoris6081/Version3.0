using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

//�o�{���b�޲z�C�������W�����s
public class SMeneger : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip ButtonSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Play()
    {
        //�}�l�C��
        //AudioSource.PlayOneShot(ButtonSound);

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
        //EditorApplication.isPlaying = false;
    }

    public void back()
    {
        //�^��C������
        SceneManager.LoadScene(0);
    }
    public void choose()
    {
        
        //�^��C������
        SceneManager.LoadScene(3);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void continue11()
    {
        SceneManager.LoadScene(4);
    }

    public void continue12()
    {
        SceneManager.LoadScene(6);
    }

    public void continue13()
    {
        SceneManager.LoadScene(7);
    }

    public void continue14()
    {
        SceneManager.LoadScene(8);
    }

    public void continue15()
    {
        SceneManager.LoadScene(9);
    }

    public void continue16()
    {
        SceneManager.LoadScene(10);
    }

}
