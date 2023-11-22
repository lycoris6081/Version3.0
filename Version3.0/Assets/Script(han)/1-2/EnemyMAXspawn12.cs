using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMAXspawn12 : MonoBehaviour
{
    public int maxEnemyCount = 20;
    private int currentEnemyCount = 0;

    public void IncrementEnemyCount()
    {
        currentEnemyCount++;

        if (currentEnemyCount >= maxEnemyCount)
        {
            // °±¤î¥Í¦¨¼Ä¤H
            MonsterSpawn_Flower[] spawners = FindObjectsOfType<MonsterSpawn_Flower>();
            foreach (MonsterSpawn_Flower spawner in spawners)
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
