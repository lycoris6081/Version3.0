using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnArea
{
    public Transform spawnPoint;
    public float spawnInterval = 3f;
    public int maxEnemies = 3;

    [HideInInspector]
    public float nextSpawnTime;
}



public class MonsterSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敌人的预制体
    public List<SpawnArea> spawnAreas; // 多个生成区域


    void Update()
    {
        //int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //if (Time.time >= nextSpawnTime && currentEnemyCount < maxEnemies)
        //{
        //    SpawnEnemy();
        //    nextSpawnTime = Time.time + spawnInterval;
        //}
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
        // 指定生成位置为spawnPoint的位置
        Vector3 spawnPosition = spawnArea.spawnPoint.position;

        // 实例化敌人
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

    }
}
