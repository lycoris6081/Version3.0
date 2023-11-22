﻿using System.Collections;
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
    public int spawnedEnemiesCount;
}



public class MonsterSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<SpawnArea> spawnAreas;
    public EnemyMAXspawn enemyManager;

    private bool isSpawning = true;

    void Update()
    {
        if (isSpawning)
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
            // 檢查所有生成區域的總生成敵人數量
            int totalSpawnedEnemies = 0;
            foreach (var spawnArea in spawnAreas)
            {
                totalSpawnedEnemies += spawnArea.spawnedEnemiesCount;
            }

            // 如果總生成敵人數量達到20，則停止生成
            if (totalSpawnedEnemies >= enemyManager.maxEnemyCount)
            {
                StopSpawning();
            }
        }
    }

    void SpawnEnemy(SpawnArea spawnArea)
    {
        Vector3 spawnPosition = spawnArea.spawnPoint.position;
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // 通知EnemyManager生成了一個新敵人
        enemyManager.IncrementEnemyCount();

        // 將一個腳本附加到生成的敵人，以在敵人被銷毀時通知EnemyManager
        enemy.AddComponent<EnemyController>().Initialize(enemyManager);

        // 追蹤生成的敵人數量
        spawnArea.spawnedEnemiesCount++;
    }
    public void StopSpawning()
    {
        isSpawning = false;
        Debug.Log("生成達20隻");
    }
}

public class EnemyController : MonoBehaviour
{
    private EnemyMAXspawn enemyManager;

    public void Initialize(EnemyMAXspawn manager)
    {
        enemyManager = manager;
    }

    void OnDestroy()
    {
        if (enemyManager != null)
        {
            enemyManager.DecrementEnemyCount();
        }
    }
}
