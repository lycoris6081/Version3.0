using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePass15 : MonoBehaviour
{
    public int sprintCount = 0; // 冲刺次数
    private int enemyCount = 0; // 用于跟踪击倒的敌人数量

    public static bool PASS11 = false;


    public GameObject Pass;
    public GameObject Clear;
    public GameObject WinButton; // 参考过关按钮的GameObject
    private float showPassTimer = 0f; // 用于计时显示过关图像的时间


  
    // 在Start方法中初始化计数并禁用亮图像

    AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        sprintCount = 0;
        enemyCount = 0;
        Pass.SetActive(false);
        Clear.SetActive(false);
        WinButton.SetActive(false);
    }
    private void Update()
    {
      
        if(PASS11 == true)
        {
            // 设置过关图像为激活状态
            Pass.SetActive(true);

            // 增加显示过关图像的计时器
            showPassTimer += Time.deltaTime;

            if (showPassTimer >= 3f)
            {
                // 3秒后，禁用过关图像
                Pass.SetActive(false);
                Clear.SetActive(true);
                // 启用过关按钮
                WinButton.SetActive(true);
            }
          
        }
    }

    // 在这里增加冲刺次数的方法
    public void IncreaseSprintCount()
    {
        sprintCount++;

        if (sprintCount >= 10)
        {

            Debug.Log("冲刺次数达到10！");
           
            PlayerPrefs.SetInt("PASS11", 1); // 将通关状态存储为1
        }
    }
    public void EnemyDown()
    {
        enemyCount++;

        if (enemyCount >= 60)
        {
            Debug.Log("擊倒10個敵人！");
           
            PlayerPrefs.SetInt("PASS12", 1); // 将通关状态存储为1
        }
    }

    

}
