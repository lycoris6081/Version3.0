using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text enemyCountText;
    private int enemyCount = 0;

    private void Start()
    {
        UpdateEnemyCountText();
    }

    private void UpdateEnemyCountText()
    {
        enemyCountText.text = "Enemy Count: " + enemyCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCount++;
            UpdateEnemyCountText();
            Destroy(other.gameObject); // 或者執行其他消滅敵人的操作
        }
    }
}

