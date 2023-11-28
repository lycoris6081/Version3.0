using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public GameObject[] images; // 放置你的六張圖片的陣列
    public Button nextLevelButton; // 按鈕來觸發顯示圖片的過程

    void Start()
    {
        // 初始化，將所有圖片設置為不可見
        foreach (var image in images)
        {
            image.SetActive(false);
        }

        // 設置按鈕點擊事件
        nextLevelButton.onClick.AddListener(ShowImagesAndLoadNextLevel);
    }

    void ShowImagesAndLoadNextLevel()
    {
        StartCoroutine(DisplayImages());
    }

    IEnumerator DisplayImages()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < images.Length; i++)
        {
            // 顯示圖片
            images[i].SetActive(true);

            // 將圖片的sortingOrder設置為最上面（假設你的圖片有Renderer組件）
            Renderer renderer = images[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sortingOrder = i + 1;
            }

            yield return new WaitForSeconds(0.5f);
        }

        // 延遲一秒後進入下一個關卡（假設你有兩個關卡）
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(3);
    }
}



