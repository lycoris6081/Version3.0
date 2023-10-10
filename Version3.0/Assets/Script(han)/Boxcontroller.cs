using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcontroller : MonoBehaviour
{

    public GameObject BoxPrefab;

    public int NeedsSoul = 10;//需要的靈魂數量

    private bool IsBoxSpawned = false;
    private int currentSoulCount = 0; // 当前的灵魂获取量
    

    public void CheckSoulcount(int soulCount)
    {
        if(!IsBoxSpawned && soulCount >= NeedsSoul)
        {
            SpawnBox();
            NeedsSoul += 10;
        }

    }


    void SpawnBox()
    {
        Instantiate(BoxPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        IsBoxSpawned = true;
       
    }

    public void DestroyBox()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("Box"));
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
