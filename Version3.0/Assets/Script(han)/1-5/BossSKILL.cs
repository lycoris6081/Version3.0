using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class SpawnRegion
{
    public Transform spawnPoint;
    public float spawnInterval = 5f; // 间隔时间
    public int maxEnemies = 5; // 最大重生数量


    [HideInInspector]
    public float nextSpawnTime;
}

public class BossSKILL : MonoBehaviour
{
    Animator animator;
    
    public GameObject[] enemyPrefabs; // 敌人的预制体数组
    public GameObject EnemyspawnreadyPrefab; // 预备标志的预制体
    public GameObject LandingCircle;
    public List<SpawnRegion> spawnAreas; // 多个生成区域
    public GameObject player;


    void Start()
    {
        // 开始生成
        foreach (var spawnArea in spawnAreas)
        {
            StartCoroutine(SpawnEnemiesInRegion(spawnArea));
        }
        // 获取玩家对象（假设玩家对象是场景中唯一带有 Playercontroller 组件的对象）
        player = FindObjectOfType<Playercontroller>().gameObject;
        animator.SetTrigger("IDLE");
    }

    IEnumerator SpawnEnemiesInRegion(SpawnRegion spawnArea)
    {
        while (true)
        {
            int enemiesToSpawn = Random.Range(3, spawnArea.maxEnemies + 1); // 随机生成数量
            
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Vector3 spawnPosition = spawnArea.spawnPoint.position;

                // 添加一个随机偏移，以在指定区域内随机生成
                float randomX = Random.Range(-15f, 15f); // 根据需要调整X轴的随机范围
                float randomY = Random.Range(-15f, 2f); // 根据需要调整Y轴的随机范围
                spawnPosition += new Vector3(randomX, randomY, 0);

                // 实例化 "ready" 标志
                GameObject readyObject = Instantiate(EnemyspawnreadyPrefab, spawnPosition, Quaternion.identity);

                // 等待一段时间后生成敌人
                yield return new WaitForSeconds(spawnArea.spawnInterval);

                // 实例化敌人
                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPosition, Quaternion.identity);
                Destroy(readyObject);

                // 触发上升操作
                float yOffsetAboveScreen = 50f; // 螢幕上方的Y軸偏移，根据需要调整
                Vector3 aboveScreenPosition = new Vector3(transform.position.x, transform.position.y + yOffsetAboveScreen, transform.position.z);
                yield return StartCoroutine(MoveToPosition(aboveScreenPosition, 0.8f));

                // 等待一段時間
                yield return new WaitForSeconds(3f);

                // 生成 LandingCircle
                Vector3 landingIndicatorPosition = player.transform.position;
                StartCoroutine(SpawnLandingCircle(landingIndicatorPosition));

                // 等待一段时间
                yield return new WaitForSeconds(3f);

                // 触发下降操作
                Vector3 descentPosition = landingIndicatorPosition;
                yield return StartCoroutine(MoveToPosition(descentPosition, 0.5f));
                
                // 等待一段时间
                yield return new WaitForSeconds(3f);

            }
           
            
            // 更新已生成的敌人数量
            spawnArea.nextSpawnTime = Time.time + spawnArea.spawnInterval;

          
            yield return null;
        }
        
    }
    IEnumerator SpawnLandingCircle(Vector3 position)
    {
      
        // 实例化 LandingCircle 在玩家当前位置
        GameObject landingIndicator = Instantiate(LandingCircle, position, Quaternion.identity);

        // 等待一段时间
        yield return new WaitForSeconds(3f);

        // 隱藏範圍預示
        Destroy(landingIndicator);
    }

    IEnumerator MoveToPosition(Vector3 targetPosition, float duration = 0.6f)
    {
        float elapsedTime = 0f;

       
        Vector3 initialPosition = transform.position;

     
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            // 使用SmoothStep函數，使移動更平滑
            t = Mathf.SmoothStep(0f, 1f, t);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);


          

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

     

    }
}