using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMAXspawn14 : MonoBehaviour
{
    public int maxEnemyCount = 20;
    private int currentEnemyCount = 0;

    public void IncrementEnemyCount()
    {
        currentEnemyCount++;

        if (currentEnemyCount >= maxEnemyCount)
        {
            // ����ͦ��ĤH
            MonsterSpawner14[] spawners = FindObjectsOfType<MonsterSpawner14>();
            foreach (MonsterSpawner14 spawner in spawners)
            {
                spawner.StopSpawning();
            }
        }
    }

    public void DecrementEnemyCount()
    {
        currentEnemyCount--;
    }
}
