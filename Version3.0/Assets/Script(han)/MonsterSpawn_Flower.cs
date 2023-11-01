using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterSpawnRegion
{
    public Transform spawnPoint;
    public float spawnInterval = 3f;
    public int maxEnemies = 3;

    [HideInInspector]
    public float nextSpawnTime;
}

public class MonsterSpawn_Flower : MonoBehaviour
{
    public GameObject enemyPrefab; // 敌人的预制体
    public List<SpawnArea> spawnAreas; // 多个生成区域

    void Update()
    {
        foreach (var spawnArea in spawnAreas)
        {
            int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (Time.time >= spawnArea.nextSpawnTime && currentEnemyCount < spawnArea.maxEnemies)
            {
                SpawnEnemy(spawnArea);
                spawnArea.nextSpawnTime = Time.time + spawnArea.spawnInterval;
            }
        }
    }

    void SpawnEnemy(SpawnArea spawnArea)
    {
        // 获取生成区域的位置
        Vector3 spawnPosition = spawnArea.spawnPoint.position;

        // 添加一个随机偏移，以在指定区域内随机生成
        float randomX = Random.Range(-10f, 10f); // 根据需要调整X轴的随机范围
        float randomY = Random.Range(-10f, 10f); // 根据需要调整Y轴的随机范围
        spawnPosition += new Vector3(randomX, randomY, 0);

        // 实例化敌人
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}