﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcontroller : MonoBehaviour
{

    public GameObject BoxPrefab;
    public GameObject ArrowIndicatorPrefab; // 箭头预制体
    [Header("需要的靈魂數量")]
    public int NeedsSoul = 10;//需要的靈魂數量

    private bool IsBoxSpawned = false;
    private int currentSoulCount = 0; // 当前的灵魂获取量
    private GameObject Arrow; // 用于存储箭头的引用

    public AudioClip BoxOpen;
    AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void CheckSoulcount(int soulCount)
    {
        if(!IsBoxSpawned && soulCount >= NeedsSoul)
        {
            SpawnBox();
            AudioSource.PlayOneShot(BoxOpen);
            NeedsSoul += 10;
        }

    }


    void SpawnBox()
    {
        // 随机生成箱子的位置
        float randomX = Random.Range(-16f, 15f); // 你可以根据需要调整范围
        float randomY = Random.Range(-16f, 5f); // 你可以根据需要调整范围
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        GameObject box = Instantiate(BoxPrefab, spawnPosition, Quaternion.identity); 
        IsBoxSpawned = true;

       
    }

    public void DestroyBox()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("Box"));
        Destroy(Arrow); // 销毁箭头
        IsBoxSpawned = false;
    }

    public void AddSoulToCurrentCount(int souls)
    {
        currentSoulCount += souls;
    }

    public int GetCurrentSoulCount()
    {
        return currentSoulCount;
    }
}
