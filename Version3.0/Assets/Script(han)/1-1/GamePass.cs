using UnityEngine;
using UnityEngine.UI;

public class GamePass : MonoBehaviour
{
    [Header("各種計算數量")]
    public Text enemyCountText; // 用于显示敌人计数的UI文本
    [Tooltip("衝刺次數")]
    public int sprintCount = 0; // 冲刺次数
    [Tooltip("擊倒的敵人數")]
    public int enemyCount = 0; // 用于跟踪击倒的敌人数量

    // conditiion 1 D = notyet B = pass
    [Header("條件1 image 上面放暗的 下面放亮的")]
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
    [Header("條件2 image 上面放暗的 下面放亮的")]
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

    [Header("遊戲內物件")]
    public GameObject img_Pass;
    public GameObject img_Clear;
    public GameObject WinButton; // 参考过关按钮的GameObject
    private float showPassTimer = 0f; // 用于计时显示过关图像的时间

    

    // 在Start方法中初始化计数并禁用亮图像
    private void Start()
    {
        sprintCount = 0;
        enemyCount = 0;
        img_Pass.SetActive(false);
        img_Clear.SetActive(false);
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
            Image5.SetActive(false);
            Image6.SetActive(true);

        }
        else
        {
            pass1D.SetActive(true);
            pass1B.SetActive(false);
            Image2.SetActive(false);
            Image1.SetActive(true);
            Image6.SetActive(false);
            Image5.SetActive(true);
        }

        if (PASS12 == true)
        {
            pass2B.SetActive(true);
            pass2D.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(true);
            Image7.SetActive(false);
            Image8.SetActive(true);

        }
        else
        {
            pass2D.SetActive(true);
            pass2B.SetActive(false);
            Image4.SetActive(false);
            Image3.SetActive(true);
            Image8.SetActive(false);
            Image7.SetActive(true);
        }

        if (PASS11 && PASS12 == true)
        {
            img_Pass.SetActive(true);
            showPassTimer += Time.deltaTime;

            if (showPassTimer >= 3f)
            {
                img_Pass.SetActive(false);
                img_Clear.SetActive(true);
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
