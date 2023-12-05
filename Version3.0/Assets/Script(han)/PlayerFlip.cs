using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void PictureFlip()
    {
        // 獲取滑鼠在相機中的位置
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 計算滑鼠相對於角色的位置
        float relativeX = mousePos.x - transform.position.x;

        // 計算滑鼠相對於角色中點的位置
        float relativeXCentered = relativeX / Mathf.Abs(relativeX);

        // 根據相對位置切換圖片
        if (relativeXCentered > 0)
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
