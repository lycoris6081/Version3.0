using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

//這程式在管理遊戲介面上的按鈕
public class SMeneger : MonoBehaviour
{
    public void Play()
    {
        //開始遊戲

        
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
        EditorApplication.isPlaying = false;
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
}
