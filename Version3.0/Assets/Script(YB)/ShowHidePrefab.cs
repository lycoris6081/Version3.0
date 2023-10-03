using UnityEngine;

public class ShowHidePrefab : MonoBehaviour
{
    public GameObject[] prefabs; // 這裡放入你的15個Prefab
    private int currentIndex = 0;
    private float timer = 0f;
    public float interval = 1f; // 1秒顯示一個Prefab
    public bool repeat = true; // 是否啟用重複循環
    public bool hideLastPrefab = true; // 是否要將最後一個Prefab設置為不可見

    private void Start()
    {
        // 開始時，將所有Prefab設置為不可見
        foreach (var prefab in prefabs)
        {
            prefab.SetActive(false);
        }

        // 啟動第一個Prefab的顯示
        ShowNextPrefab();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;

            // 顯示下一個Prefab，如果已經顯示完所有的Prefab，則根據repeat變數決定是否重新開始循環
            if (currentIndex < prefabs.Length)
            {
                ShowNextPrefab();
            }
            else
            {
                if (hideLastPrefab && prefabs.Length > 0)
                {
                    prefabs[prefabs.Length - 1].SetActive(false); // 將最後一個Prefab設置為不可見
                }

                if (repeat)
                {
                    currentIndex = 0; // 重設索引，重新開始循環
                    ShowNextPrefab();
                }
                else
                {
                    // 停止更新或執行其他相關的操作
                    enabled = false;
                }
            }
        }
    }

    private void ShowNextPrefab()
    {
        // 關閉上一個Prefab
        if (currentIndex > 0)
        {
            prefabs[currentIndex - 1].SetActive(false);
        }

        // 顯示當前Prefab
        if (currentIndex < prefabs.Length)
        {
            prefabs[currentIndex].SetActive(true);
        }

        currentIndex++;
    }
}
