using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayercontrollerEndLess : MonoBehaviour
{

    public GamePass gameMenager; // 参考GameManager脚本
    public bool game1pass = false;
    public float moveSpeed = 5f;
    public float sprintSpeed = 5f; // 冲刺速度
    public float maxSprintSpeed = 10f; // 冲刺最大速度
    public float sprintDistance = 5f; // 冲刺距离
    public GameObject AttackBox;

    


    /*public float knockbackForce = 5f;*/ // 物理衝撞反射的大小

    public static bool isAttacking;
    private bool isWalking = false;
    private bool isSprinting = false;
    private bool canSprint = true; // 用于控制是否可以进行冲刺
   

    private Vector3 targetPosition;
    private float initialDistance;
    private Rigidbody2D rb; // Rigidbody2D组件

    private CardControl CCUI;

    private SoulUI UI;//靈魂收集數量顯示
    private Boxcontroller Box;

   
    public Animator animator;

    private Vector2 originalVelocity; // 用于保存原始速度
    private float sprintTimer = 0f; // 用于计时衝刺持续时间

    [Header("音效")]
    public AudioClip SFX_hitSound;
    
    AudioSource AudioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 获取Rigidbody2D组件
        AudioSource = GetComponent<AudioSource>();
       
        rb.gravityScale = 0; // 防止重力影响
        AttackBox.SetActive(false);
        UI = GameObject.Find("SoulScript").GetComponent<SoulUI>();
        Box = GameObject.Find("BoxControl").GetComponent<Boxcontroller>();
        CCUI = GameObject.Find("Cardsystem").GetComponent<CardControl>();
        // 获取对GameManager脚本的引用
        gameMenager = GameObject.Find("GameMenager").GetComponent<GamePass>();
        
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
        //PlayHitSound();




        if (Input.GetMouseButtonDown(0) && canSprint)
        {
            // 禁止再次点击鼠标
            canSprint = false;
            AudioSource.PlayOneShot(SFX_hitSound);

            isAttacking = true;
            AttackBox.SetActive(true);
           
            animator.SetFloat("Attack1", 1);
            
            isSprinting = true;
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            initialDistance = Vector3.Distance(transform.position, targetPosition);
            
            

            // 保存原始速度
            originalVelocity = rb.velocity;

            // 设置速度为最大冲刺速度
            Vector3 moveDirection = (targetPosition - transform.position);
            rb.velocity = moveDirection.normalized * maxSprintSpeed;

            // 启动衝刺计时器
            sprintTimer = 0.1f;

           

        }
        else if (isSprinting)
        {
            // 更新衝刺计时器
            sprintTimer -= Time.deltaTime;

            // 如果计时器小于等于0，停止衝刺
            if (sprintTimer <= 0f)
            {
                // 允许再次点击鼠标
                canSprint = true;
                isSprinting = false;
                rb.velocity = originalVelocity;
                
                animator.SetFloat("Attack1", 0);

               
                gameMenager.IncreaseSprintCount();

            }                    
        }
        else
        {
            
            isAttacking = false;
            AttackBox.SetActive(false);
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

       void GameStop()
       {
             //游戏时间，以防止继续更新游戏状态
            StartCoroutine(DelayedGameOver());
            
       }

        if(PlayerHP.Isdead == true)
        {
            //AudioSource.PlayOneShot(SFX_dieSound);
            animator.SetFloat("DEAD1", 1);
            GameStop();

        }
        else
        {
            animator.SetFloat("DEAD1", 0);
        }
        IEnumerator DelayedGameOver()
        {

            yield return new WaitForSeconds(0.5f); // 等待0.3秒

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

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Soul"))
        {
            CollectSoul(other.gameObject);
        }
        else if (other.CompareTag("Box"))
        {
            CollectBox(other.gameObject);
        }
    }


    void CollectSoul(GameObject Soul)
    {
        UI.CollectSoul();
        Destroy(Soul);
        Box.AddSoulToCurrentCount(1);
        Box.CheckSoulcount(UI.GetSoulCount());
    }


    void CollectBox(GameObject box)
    {
        
        Box.DestroyBox(); // 销毁箱子
        CCUI.CollectBox();//叫出選擇介面
       
    }


    void PlayHitSound()
    {
        if (isAttacking == true)
            AudioSource.PlayOneShot(SFX_hitSound);
    }
    
}

