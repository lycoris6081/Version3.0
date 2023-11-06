using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePass12 : MonoBehaviour
{
    public int sprintCount = 0; // 冲刺次数
    private int enemyCount = 0; // 用于跟踪击倒的敌人数量

    public bool PASS11 = false;
    public GameObject pass1D;
    public GameObject pass1B;
    public bool PASS12 = false;
    public GameObject pass2D;
    public GameObject pass2B;
    public GameObject Pass;
    public GameObject WinButton; // 参考过关按钮的GameObject
    private float showPassTimer = 0f; // 用于计时显示过关图像的时间

    // 在Start方法中初始化计数并禁用亮图像
    private void Start()
    {
        AbilityControl.Ability6UsageCount = 0;
        sprintCount = 0;
        enemyCount = 0;
        Pass.SetActive(false);
        WinButton.SetActive(false);
    }
    private void Update()
    {
        //1-2 過關條件
        if (SoulUI.soulCount >= 50 && AbilityControl.Ability6UsageCount >= 5)
        {
            pass1B.SetActive(true);
            pass1D.SetActive(false);
            PASS11 = true;
        }
        else
        {
            pass1D.SetActive(true);
            pass1B.SetActive(false);
        }
        if (PASS12 == true)
        {
            pass2B.SetActive(true);
            pass2D.SetActive(false);
        }
        else
        {
            pass2D.SetActive(true);
            pass2B.SetActive(false);
        }

        if(PASS11&&PASS12 == true)
        {
            // 设置过关图像为激活状态
            Pass.SetActive(true);

            // 增加显示过关图像的计时器
            showPassTimer += Time.deltaTime;

            if (showPassTimer >= 3f)
            {
                // 3秒后，禁用过关图像
                Pass.SetActive(false);

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
            PASS11 = true;
            PlayerPrefs.SetInt("PASS11", 1); // 将通关状态存储为1
        }
    }
    public void EnemyDown()
    {
        enemyCount++;

        if (enemyCount >= 10)
        {
            Debug.Log("擊倒10個敵人！");
            PASS12 = true;
            PlayerPrefs.SetInt("PASS12", 1); // 将通关状态存储为1
        }
    }
    public void WIN()
    {
        SceneManager.LoadScene(3);
    }

}
