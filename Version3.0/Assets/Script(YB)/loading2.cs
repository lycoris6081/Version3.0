using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class loading2 : MonoBehaviour
{
    public GameObject[] images; // 放置你的九張圖片的陣列
    public GameObject panel; // Panel 對象

    void Start()
    {
        // 初始化，將所有圖片設置為可見
        foreach (var image in images)
        {
            image.SetActive(true);
        }

        // 啟動協程，延遲0.5秒後開始隱藏圖片
        StartCoroutine(HideImages());
    }

    IEnumerator HideImages()
    {
        // 延遲0.5秒
        yield return new WaitForSeconds(0.5f);

        // 依次隱藏每張圖片
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        // 延遲0.5秒
        yield return new WaitForSeconds(0.5f);

        // 關閉 Panel
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}