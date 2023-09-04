using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;



    void Update()
    {
        // 獲取滑鼠當前的屏幕位置
        Vector3 mousePosition = Input.mousePosition;

        // 將滑鼠位置從屏幕坐標轉換為世界坐標
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));

        // 計算物體到滑鼠位置的方向向量
        Vector3 moveDirection = worldMousePosition - transform.position;

        // 鎖住Z軸，使物體保持在2D平面上
        moveDirection.z = 0;

        // 正規化方向向量，以確保速度一致
        moveDirection.Normalize();

        // 設置物體的位置
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

       
    }

    
}

