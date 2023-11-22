using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Flower : MonoBehaviour

{

     Animator animator;

    public int hp = 0;

    private static int Boomhp = 0;

    public enum Face { Right, Left };
    public Face face;

    public GameObject SoulPrefab;

    public int minSouls = 3; // 最少掉落的灵魂数量
    public int maxSouls = 4; // 最多掉落的灵魂数量

    public Transform playerTransform;

    private bool isDead = false;
    public static bool Boom = false;
    private SpriteRenderer spriteRenderer;
    private float flashDuration = 0.1f;
    private Color originalColor;
    void Start()
    {
       
        hp = 2;

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;




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

    public void Dead()
    {
        //// 播放死亡动画或其他操作
        //animator.SetFloat("Die", 1);

        //// 延迟一定时间后销毁对象
        //Invoke("DestroyEnemy", 1f);
        Destroy(this.gameObject);
        SoulSpawn();
    }

    //public void DestroyEnemy()
    //{
    //    Destroy(this.gameObject);
    //    SoulSpawn();
    //}

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




    // Update is called once per frame
    void Update()
    {
        

        if (!isDead && hp <= 0)
        {
            isDead = true;
            Dead();


            GameObject gameManager = GameObject.Find("GameMenager");
            if (gameManager != null)
            {
                GamePass12 gamePass = gameManager.GetComponent<GamePass12>();
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

  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackBox")
        {
            TakeDamage(AttackBox.Damage);
            Debug.Log("-1");
        }
        if (other.gameObject.tag == "Shield")
        {

            hp = 0;


        }

    }


 

}









