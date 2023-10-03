using UnityEngine;
using UnityEngine.UI;

public class ImageGenerator : MonoBehaviour
{
    public Image[] imagePrefabs;   // 用于存储不同Prefab的数组
    public RectTransform panel;    // 在Unity中将面板的RectTransform组件分配给这个变量
    public float spawnInterval = 2f; // 生成图片的间隔时间
    public float moveSpeed = 100f;  // 图片移动的速度
    public float destroyTime = 4f;  // 图片销毁的时间

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // 随机选择一个Prefab
            int randomPrefabIndex = Random.Range(0, imagePrefabs.Length);
            Image selectedPrefab = imagePrefabs[randomPrefabIndex];

            // 生成图片
            Image newImage = Instantiate(selectedPrefab, panel);

            // 随机生成图片的位置在面板内
            RectTransform imageRect = newImage.rectTransform;
            Vector2 panelSize = panel.rect.size;
            float randomX = Random.Range(-panelSize.x / 2, panelSize.x / 2);
            float randomY = Random.Range(-panelSize.y / 2, panelSize.y / 2);
            imageRect.anchoredPosition = new Vector2(randomX, randomY);

            // 向前位移图片
            Rigidbody2D rb = newImage.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.right * moveSpeed;
            }

            // 在一段时间后销毁图片
            Destroy(newImage.gameObject, destroyTime);

            // 更新下一个生成时间
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
