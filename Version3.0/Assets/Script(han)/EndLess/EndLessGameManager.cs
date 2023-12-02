using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndLessGameManager : MonoBehaviour
{
    public static EndLessGameManager instance;  // 创建一个单例以方便其他脚本访问
    public GameObject victoryPanel;  // 通关的面板

    private void Awake()
    {
        victoryPanel.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckWaveComplete()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // 使用特定的标签

        // 检查是否当前波次的敌人已全部被击败
        if (enemies.Length == 0)
        {
            StartCoroutine(ShowVictoryPanel());
        }
    }

    IEnumerator ShowVictoryPanel()
    {
        Debug.Log("Wave Clear");
        // 显示通关面板，你可以在这里添加一些额外的效果或动画
        victoryPanel.SetActive(true);

        // 等待几秒钟后隐藏通关面板，你可以调整等待时间
        yield return new WaitForSeconds(3f);

        victoryPanel.SetActive(false);

        // 进行下一波或其他操作
    }
}