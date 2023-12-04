using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstercontroller : MonoBehaviour

{

    Animator animator;
    
    public int hp = 0;

    private static int Boomhp = 0;

    public enum Status { walk, attack };
    public Status status;
    public enum Face { Right, Left };
    public Face face;

    public GameObject SoulPrefab;

    public int minSouls = 1; // 最少掉落的灵魂数量
    public int maxSouls = 2; // 最多掉落的灵魂数量
    public float Speed;
    public float VerticalSpeed; //垂直移動變數
    private Transform myTransform;

    public Transform playerTransform;
    private SpriteRenderer spr;

    public Collider2D wallCollider; // 牆壁的碰撞器
    private bool isDead = false;
    private bool isAttacked = false;

    public static bool Boom = false;

    private SpriteRenderer spriteRenderer;
    private float flashDuration = 0.1f;
    private Color originalColor;
    void Start()
    {
        Boomhp = 0;
        hp = 3;
        status = Status.walk;
       
        spr = this.transform.GetComponent<SpriteRenderer>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        if (spr.flipX)
        {
            face = Face.Right;
        }
        else
        {
            face = Face.Left;
        }
        myTransform = this.transform;
        playerTransform = GameObject.Find("CATCAT").transform;

        //// 获取怪物的碰撞器
        //Collider2D monsterCollider = GetComponent<Collider2D>();

        //// 忽略与牆壁的碰撞
        //if (wallCollider != null && monsterCollider != null)
        //{
        //    Physics2D.IgnoreCollision(wallCollider, monsterCollider);
        //}
       animator = GetComponent<Animator>();
    }

    void SoulSpawn()
    {

        int soulCount = Random.Range(minSouls, maxSouls + 1); // 随机掉落1到2颗灵魂

        for (int i = 0; i < soulCount; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0); // 随机生成掉落位置
            GameObject Soul = Instantiate(SoulPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("soul");

            Destroy(Soul, 2f); // 假设2秒后销毁灵魂对象，根据需要进行调整
        }

    }

    void Dead()
    {
        Destroy(this.gameObject);
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage; // 減少敵人的血量
        StartCoroutine(FlashWhite());
    }
    private System.Collections.IEnumerator FlashWhite()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    private IEnumerator SlowDown(float duration = 5f)
    {
        // 保存原始速度
        float originalSpeed = Speed;
        float originalVerticalSpeed = VerticalSpeed;

        // 減慢速度
        Speed /= 4;
        VerticalSpeed /= 4;

        // 等待持續時間
        yield return new WaitForSeconds(duration);

        // 恢復正常速度
        Speed = originalSpeed;
        VerticalSpeed = originalVerticalSpeed;
    }

    private void SlowdownEnemiesWithTag(string tag, float duration)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject enemy in enemies)
        {
            Monstercontroller enemyController = enemy.GetComponent<Monstercontroller>();
            if (enemyController != null)
            {
                enemyController.StartCoroutine(enemyController.SlowDown(duration));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
  
       if (!isDead&&hp <= 0)
       {
          isDead = true;
          animator.SetFloat("Die", 1);
          Invoke("Dead", 0.2f);
          Invoke("SoulSpawn", 0.2f);

            GameObject gameManager = GameObject.Find("GameMenager");
            if (gameManager != null)
            {
                GamePass gamePass = gameManager.GetComponent<GamePass>();
                if (gamePass != null)
                {
                    gamePass.EnemyDown();
                }
            }

        }

       if (AbilityControl.Boom == true)
       {
        
        Boomhp--; // 只在Boom為true時減少hp
        AbilityControl.Boom = false; // 重置Boom為false，以便下一次觸發


       }

        if (AbilityControl.Slowdown)
        {
            SlowdownEnemiesWithTag("Enemy", 2f); // 假設要減慢10秒

            // 重置 Slowdown 為 false，以便下一次觸發
            AbilityControl.Slowdown = false;
        }



        float deltaTime = Time.deltaTime;
        //STATUS UPDATE
        switch (status)
        {
            case Status.walk:

                animator.SetBool("walk", true);

                if (myTransform.position.x >= playerTransform.position.x)
                {
                    spr.flipX = false;
                    face = Face.Left;
                }
                else
                {
                    spr.flipX = true;
                    face = Face.Right;
                }
                switch (face)

                {
                    case Face.Right:
                        myTransform.position += new Vector3(Speed * deltaTime, 0, 0);
                        break;
                    case Face.Left:
                        myTransform.position -= new Vector3(Speed * deltaTime, 0, 0);
                        break;
                }

                // 控制垂直移动
                if (myTransform.position.y < playerTransform.position.y)
                {
                    myTransform.position += new Vector3(0, VerticalSpeed * deltaTime, 0);
                }
                else if (myTransform.position.y > playerTransform.position.y)
                {
                    myTransform.position -= new Vector3(0, VerticalSpeed * deltaTime, 0);
                }
                break;



        }


    }

    





    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackBox")
        {
            TakeDamage(AttackBox.Damage);


        }
        if (other.gameObject.tag == "Shield")
        {

            hp = 0;
           

        }

    }


}

   
    






