using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn_EndLess_CUP : MonoBehaviour
{
    public Transform[] spawnPoints; // 重生点数组
    public GameObject enemyPrefab; // 敌人Prefab
    public float[] spawnIntervals; // 每个重生点的生成间隔
    

    void Start()
    {
        // 启动协程，等待一段时间后开始生成敌人
        StartCoroutine(DelayedSpawnEnemies());
    }

    IEnumerator DelayedSpawnEnemies()
    {
        yield return new WaitForSeconds(120f); // 等待80秒

        while (true)
        {
            // 在随机的重生点生成敌人
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomSpawnPointIndex];

         
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // 根据当前重生点的生成间隔等待一段时间
            yield return new WaitForSeconds(spawnIntervals[randomSpawnPointIndex]);
        }
    }
}
