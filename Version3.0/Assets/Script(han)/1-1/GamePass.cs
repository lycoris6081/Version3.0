using UnityEngine;
using UnityEngine.UI;

public class GamePass : MonoBehaviour
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
    public GameObject Clear;
    public GameObject WinButton; // 参考过关按钮的GameObject
    private float showPassTimer = 0f; // 用于计时显示过关图像的时间

    public GameObject Image1; // 图像1
    public GameObject Image2; // 图像2
    public GameObject Image3; // 图像3
    public GameObject Image4; // 图像4
    public Text enemyCountText; // 用于显示敌人计数的UI文本

    // 在Start方法中初始化计数并禁用亮图像
    private void Start()
    {
        sprintCount = 0;
        enemyCount = 0;
        Pass.SetActive(false);
        Clear.SetActive(false);
        WinButton.SetActive(false);
        UpdateEnemyCountText();
    }

    private void Update()
    {
        // 1-1 過關條件
        if (PASS11 == true)
        {
            pass1B.SetActive(true);
            pass1D.SetActive(false);
            Image1.SetActive(false);
            Image2.SetActive(true);
        }
        else
        {
            pass1D.SetActive(true);
            pass1B.SetActive(false);
            Image2.SetActive(false);
            Image1.SetActive(true);
        }

        if (PASS12 == true)
        {
            pass2B.SetActive(true);
            pass2D.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(true);
        }
        else
        {
            pass2D.SetActive(true);
            pass2B.SetActive(false);
            Image4.SetActive(false);
            Image3.SetActive(true);
        }

        if (PASS11 && PASS12 == true)
        {
            Pass.SetActive(true);
            showPassTimer += Time.deltaTime;

            if (showPassTimer >= 3f)
            {
                Pass.SetActive(false);
                Clear.SetActive(true);
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

    // 在这里增加击倒敌人的方法
    public void EnemyDown()
    {
        enemyCount++;

        if (enemyCount >= 20)
        {
            Debug.Log("擊倒20個敵人！");
            PASS12 = true;
            PlayerPrefs.SetInt("PASS12", 1); // 将通关状态存储为1
        }

        UpdateEnemyCountText();
    }

    private void UpdateEnemyCountText()
    {
        enemyCountText.text = enemyCount.ToString();
    }
}
