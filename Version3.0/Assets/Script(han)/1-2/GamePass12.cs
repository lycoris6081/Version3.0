using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GamePass12 : MonoBehaviour
{
    [Header("各種計算數量")]
    public int sprintCount = 0; // 冲刺次数
    private int enemyCount = 0; // 用于跟踪击倒的敌人数量
    public TextMeshProUGUI enemyCountText; // 用于显示敌人计数的UI文本
    
    [Header("image 上面放暗的 下面放亮的")]

    [Header("條件1")]
    public bool PASS11 = false;
    [Header(" [遊戲內]")]
    [Tooltip("遊戲內，暗的")]
    public GameObject pass1D;
    [Tooltip("遊戲內，亮的")]
    public GameObject pass1B;
    [Header(" [暫停]")]
    [Tooltip("暗的")]
    public GameObject Image1; // 图像1
    [Tooltip("亮的")]
    public GameObject Image2; // 图像2
    [Header(" [失敗結算]")]
    public GameObject Image5;
    public GameObject Image6;

    // condition 2
    [Header("條件2")]
    public bool PASS12 = false;
    [Header(" [遊戲內]")]
    public GameObject pass2D;
    public GameObject pass2B;
    [Header(" [暫停]")]
    public GameObject Image3; // 图像3
    public GameObject Image4; // 图像4
    [Header(" [失敗結算]")]
    public GameObject Image7;
    public GameObject Image8;
    public GameObject Image9;
    public GameObject Image10;
    public GameObject Image11;
    public GameObject Image12;

    [Header("遊戲內物件")]
    public GameObject Pass;
    public GameObject Clear;
    public GameObject WinButton; // 参考过关按钮的GameObject
    private float showPassTimer = 0f; // 用于计时显示过关图像的时间

    AudioSource AudioSource;



    // 在Start方法中初始化计数并禁用亮图像
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AbilityControl.Ability6UsageCount = 0;
        sprintCount = 0;
        enemyCount = 0;
        Pass.SetActive(false);
        Clear.SetActive(false);
        WinButton.SetActive(false);
    }
    private void Update()
    {
        //1-2 過關條件
        if (SoulUI.soulCount >= 1 && AbilityControl.Ability6UsageCount >= 1)
        {
            pass1B.SetActive(true);
            pass1D.SetActive(false);
            PASS11 = true;
            Image1.SetActive(false);
            Image2.SetActive(true);
            Image5.SetActive(false);
            Image6.SetActive(true);
            Image9.SetActive(false);
            Image10.SetActive(true);
        }
        else
        {
            pass1D.SetActive(true);
            pass1B.SetActive(false);
            Image2.SetActive(false);
            Image1.SetActive(true);
            Image6.SetActive(false);
            Image5.SetActive(true);
            Image10.SetActive(false);
            Image9.SetActive(true);
        }
        if (PASS12 == true)
        {
            pass2B.SetActive(true);
            pass2D.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(true);
            Image7.SetActive(false);
            Image8.SetActive(true);
            Image11.SetActive(false);
            Image12.SetActive(true);
        }
        else
        {
            pass2D.SetActive(true);
            pass2B.SetActive(false);
            Image4.SetActive(false);
            Image3.SetActive(true);
            Image8.SetActive(false);
            Image7.SetActive(true);
            Image12.SetActive(false);
            Image11.SetActive(true);
        }

        if (PASS11 && PASS12 == true)
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

         
        }
    }
    public void EnemyDown()
    {
        enemyCount++;

        if (enemyCount >=1)
        {
            Debug.Log("擊倒10個敵人！");
            PASS12 = true;
         
        }
        UpdateEnemyCountText();
    }
    private void UpdateEnemyCountText()
    {
        enemyCountText.text = enemyCount.ToString();
    }


}