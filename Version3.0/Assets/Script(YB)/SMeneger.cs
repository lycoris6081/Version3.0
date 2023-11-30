using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

//這程式在管理遊戲介面上的按鈕
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
        //開始遊戲
        //AudioSource.PlayOneShot(ButtonSound);

        SceneManager.LoadScene(1);
    }

    public void Introduce()
    {
        //操作介紹

    }

    public void Setup()
    {
        //遊戲設定
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        //離開遊戲
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }

    public void back()
    {
        //回到遊戲介面
        SceneManager.LoadScene(0);
    }
    public void choose()
    {
        
        //回到遊戲介面
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
