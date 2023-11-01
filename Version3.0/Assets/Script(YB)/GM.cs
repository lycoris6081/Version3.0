using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public Text enemyCountText;
    private int enemyCount = 0;

    // 当擊敗擁有"enemy"標籤的敵人時調用此方法
    public void EnemyDefeated()
    {
        enemyCount++;
        UpdateUI();
    }

    // 更新UI文本显示
    private void UpdateUI()
    {
        enemyCountText.text = "擊敗敵人數量: " + enemyCount.ToString();
    }
}

