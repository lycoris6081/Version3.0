using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public Image[] images; // 放置圖片的數組

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
    }
}



