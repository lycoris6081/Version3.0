using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敌人的预制体
    public float spawnInterval = 3f; // 敌人生成的时间间隔
    public int maxEnemies = 3;
    public float spawnRadius = 10f; // 环型区域的半径
    public float centerRadius = 5f; // 中心区域的半径
    private float nextSpawnTime = 3f;

    void Update()
    {
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (Time.time >= nextSpawnTime && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // 随机生成怪物的角度
        float randomAngle = Random.Range(0f, 360f);

        // 计算怪物生成的位置
        Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right * spawnRadius;


        // 检查生成位置是否在中心区域内
        float distanceToCenter = Vector3.Distance(transform.position, spawnPosition);
        if (distanceToCenter <= centerRadius)
        {
            // 生成位置在中心区域内，重新生成
            SpawnEnemy();
            return;
        }


        //// 在指定区域内随机生成敌人
        //float randomX = Random.Range(-6.4f, 6.4f); 
        //float randomY = Random.Range(-4f, 3f);
        //Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        // 实例化敌人
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
