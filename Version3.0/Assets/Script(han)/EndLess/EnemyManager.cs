using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float[] spawnIntervals;
    public int maxEnemiesPerWave;
    public int wavesCount;
    public int maxEnemiesFinalWave;

    public TMP_Text victoryTextPrefab;
    public float victoryTextDuration = 3f;

    private int currentWave = 1;
    private int enemiesSpawned = 0;

    void Start()
    {
        StartCoroutine(StartEnemyWaves());
       
    }

    IEnumerator StartEnemyWaves()
    {
        while (currentWave <= wavesCount)
        {
            yield return StartCoroutine(SpawnEnemiesInWave());

            victoryTextPrefab.text = "Wave " + currentWave + " Cleared!";
            victoryTextPrefab.gameObject.SetActive(true);
            yield return new WaitForSeconds(victoryTextDuration);
            victoryTextPrefab.gameObject.SetActive(false);
            currentWave++;
            enemiesSpawned = 0;
            Debug.Log("ENTER NEXT WAVE");
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator SpawnEnemiesInWave()
    {
        int enemiesToSpawn = Mathf.Min(maxEnemiesPerWave, maxEnemiesFinalWave - enemiesSpawned);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            float spawnInterval = spawnIntervals[spawnPointIndex];

            yield return new WaitForSeconds(spawnInterval);

            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            enemiesSpawned++;
        }
    }
   
}