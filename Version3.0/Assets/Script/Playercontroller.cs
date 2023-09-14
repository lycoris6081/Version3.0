using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 5f; // 冲刺速度
    public float lerpSpeed = 10f;  // 插值速度
    public float sprintDistance = 5f; // 冲刺距离

    private bool isWalking = false;
    private bool isSprinting = false;
    private Vector3 targetPosition;
    private float initialDistance;

        
    public Animator animator;


    void Start()
    {
       
       
    }

   
    //滑鼠移動
    void MouseMove()
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

        isWalking = true;
    }

    void Update()
    {


        
      MouseMove();

        //攻擊
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetFloat("Attack1",1);
            isSprinting = true;
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z; // 保持在同一Z轴上
            initialDistance = Vector3.Distance(transform.position, targetPosition);
        }
        else
        {
            isSprinting = false;
            animator.SetFloat("Attack1",0);
        }

        //走路動畫
        if(isWalking == true)
        {
            animator.SetFloat("WALK", 1);

        }
        else
        {
            animator.SetFloat("WALK", 0);
        }

       

        if(PlayerHP.Isdead == true)
        {
            animator.SetFloat("DEAD1", 1);
            // 停止游戏时间，以防止继续更新游戏状态
            StartCoroutine(DelayedGameOver());

        }
        else
        {
            animator.SetFloat("DEAD1", 0);
        }
        IEnumerator DelayedGameOver()
        {
            yield return new WaitForSeconds(0.3f); // 等待0.3秒

            // 停止游戏
            Time.timeScale = 0f;

           
        }




        if (isSprinting)
        {
            Vector3 moveDirection = (targetPosition - transform.position);
            transform.position = Vector3.Lerp(transform.position, moveDirection, 20 * Time.deltaTime);

            // 当物体接近目标位置或者超过冲刺距离时停止冲刺
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f || Vector3.Distance(transform.position, targetPosition) >= initialDistance + sprintDistance)
            {
                isSprinting = false;
            }
        }




    }

    
}

