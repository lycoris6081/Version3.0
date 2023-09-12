using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float lastMouseX;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastMouseX = Input.mousePosition.x;
    }

    void PictureFlip()
    {
        // 獲取滑鼠當前的X位置
        float mouseX = Input.mousePosition.x;

        // 計算滑鼠移動的方向
        float direction = Mathf.Sign(mouseX - lastMouseX);

        // 根據方向切換圖片
        if (direction > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        PictureFlip();
    }
}
