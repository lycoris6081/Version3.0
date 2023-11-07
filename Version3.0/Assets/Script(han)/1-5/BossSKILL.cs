using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnRegion
{
    public Transform spawnPoint;
    public float spawnInterval = 5f; // 间隔时间
    public int maxEnemies = 3; // 最大重生数量

    [HideInInspector]
    public float nextSpawnTime;
}

public class BossSKILL : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 敌人的预制体数组
    public GameObject EnemyspawnreadyPrefab; // 预备标志的预制体
    public List<SpawnRegion> spawnAreas; // 多个生成区域

    void Start()
    {
        // 开始生成
        foreach (var spawnArea in spawnAreas)
        {
            StartCoroutine(SpawnRandomEnemy(spawnArea));
        }
    }
    int enemyCount = 0; // 用于跟踪已生成的敌人数量

    IEnumerator SpawnRandomEnemy(SpawnRegion spawnArea)
    {
        while (true)
        {
            // 计算这次生成的敌人数量（最多不超过 maxEnemies）
            int enemiesToSpawn = Random.Range(1, spawnArea.maxEnemies - enemyCount + 1);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                if (enemyCount < spawnArea.maxEnemies)
                {
                    Vector3 spawnPosition = spawnArea.spawnPoint.position;

                    // 添加一个随机偏移，以在指定区域内随机生成
                    float randomX = Random.Range(-10f, 10f); // 根据需要调整X轴的随机范围
                    float randomY = Random.Range(-10f, 10f); // 根据需要调整Y轴的随机范围
                    spawnPosition += new Vector3(randomX, randomY, 0);

                    // 实例化 "ready" 标志
                    GameObject readyObject = Instantiate(EnemyspawnreadyPrefab, spawnPosition, Quaternion.identity);

                    // 随机选择一种敌人
                    int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
                    GameObject enemyPrefab = enemyPrefabs[randomEnemyIndex];

                    // 等待一段时间后生成敌人
                    yield return new WaitForSeconds(spawnArea.spawnInterval);

                    // 实例化敌人
                    Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    Destroy(readyObject);

                    // 更新已生成的敌人数量
                    enemyCount++;
                }
              
            }
        }
    }
}