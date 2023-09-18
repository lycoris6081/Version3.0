using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 5f; // 冲刺速度
    public float maxSprintSpeed = 10f; // 冲刺最大速度
    public float sprintDistance = 5f; // 冲刺距离
    

    public static bool isAttacking;
    private bool isWalking = false;
    private bool isSprinting = false;
    private Vector3 targetPosition;
    private float initialDistance;
    private Rigidbody2D rb; // Rigidbody2D组件

    public Animator animator;

    private Vector2 originalVelocity; // 用于保存原始速度
    private float sprintTimer = 0f; // 用于计时衝刺持续时间

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 获取Rigidbody2D组件
        rb.gravityScale = 0; // 防止重力影响

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

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetFloat("Attack1", 1);
            isSprinting = true;
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z; // 保持在同一Z轴上
            initialDistance = Vector3.Distance(transform.position, targetPosition);
            
            // 保存原始速度
            originalVelocity = rb.velocity;

            // 设置速度为最大冲刺速度
            Vector3 moveDirection = (targetPosition - transform.position);
            rb.velocity = moveDirection.normalized * maxSprintSpeed;

            // 启动衝刺计时器
            sprintTimer = 0.5f;
        }
        else if (isSprinting)
        {
            // 更新衝刺计时器
            sprintTimer -= Time.deltaTime;

            // 如果计时器小于等于0，停止衝刺
            if (sprintTimer <= 0f)
            {
                rb.velocity = originalVelocity;
                isSprinting = false;
                animator.SetFloat("Attack1", 0);
            }
        }


        //走路動畫
        if (isWalking == true)
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
            

            

            // 当物体接近目标位置或者超过冲刺距离或者计时器结束时停止冲刺
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f ||
                Vector3.Distance(transform.position, targetPosition) >= initialDistance + sprintDistance)
                
            {
                isSprinting = false;
            }
        }




    }

    
}

