using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public Image[] images; // 放置圖片的數組
    public string nextLevelName; // 要加載的下一個關卡的名稱

    private void Start()
    {
        // 初始時將所有圖片設置為不可見
        foreach (var image in images)
        {
            image.gameObject.SetActive(false);
        }
    }

    // 由按鈕的點擊事件調用的方法
    public void StartImageSequence()
    {
        StartCoroutine(ShowImagesCoroutine());
    }

    private IEnumerator ShowImagesCoroutine()
    {
        // 依次顯示圖片，每隔0.5秒顯示一張
        foreach (var image in images)
        {
            image.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }

        // 顯示圖片後等待額外的0.5秒再加載下一個關卡
        yield return new WaitForSeconds(0.5f);

        // 加載下一個關卡
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        // 檢查下一個關卡名稱是否有效
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            // 加載下一個關卡
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.LogError("未指定下一個關卡名稱。");
        }
    }
}




