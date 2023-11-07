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
    public GameObject EnemyspawnreadyPrefab; // 预备标志的预制体
    public GameObject enemyPrefab; // 敌人的预制体
    public List<MonsterSpawnRegion> spawnAreas; // 多个生成区域

    bool isReadySpawned = false;
    float readySpawnTime = 0f;

    void Start()
    {
        // 开始生成 "ready" 标志
       InvokeRepeating("InstantiateReady", 1f, 5f);
    }

    void InstantiateReady()
    {
        foreach (var spawnArea in spawnAreas)
        {
            Vector3 spawnPosition = spawnArea.spawnPoint.position;

            // 添加一个随机偏移，以在指定区域内随机生成
            float randomX = Random.Range(-10f, 10f); // 根据需要调整X轴的随机范围
            float randomY = Random.Range(-10f, 10f); // 根据需要调整Y轴的随机范围
            spawnPosition += new Vector3(randomX, randomY, 0);

            // 实例化 "ready" 标志
            GameObject readyObject = Instantiate(EnemyspawnreadyPrefab, spawnPosition, Quaternion.identity);

            // 调用生成敌人的方法
            StartCoroutine(SpawnEnemyWithDelay(readyObject, spawnArea.spawnInterval));
        }

        isReadySpawned = true;
        readySpawnTime = Time.time;
    }

    IEnumerator SpawnEnemyWithDelay(GameObject readyObject, float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 spawnPosition = readyObject.transform.position;

       
        // 实例化敌人
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Destroy(readyObject);
    }
}