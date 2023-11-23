using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_CUP14 : MonoBehaviour

{

    

    public int hp = 0;

    private static int Boomhp = 0;

    
 

    public GameObject SoulPrefab;

    public int minSouls = 3; // 最少掉落的灵魂数量
    public int maxSouls = 4; // 最多掉落的灵魂数量
    public GameObject BoomRange;

    public Transform playerTransform;
    public Rigidbody2D rb;
    private bool isDead = false;
    public static bool Boom = false;
    private SpriteRenderer spriteRenderer;
    private float flashDuration = 0.1f;
    private Color originalColor;
    void Start()
    {
       
        hp = 3;
        BoomRange.SetActive(false);
        rb = GameObject.Find("CATCAT").GetComponent<Rigidbody2D>();
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

    void Dead()
    {
        Destroy(this.gameObject);
        SoulSpawn();
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
    public void Boomdied()
    {
        BoomRange.SetActive(true);
        Invoke("Dead", 1f);
    }
  
    public void GamePass14()
    {
        GameObject gameManager = GameObject.Find("GameMenager");
        if (gameManager != null)
        {
            GamePass14 gamePass = gameManager.GetComponent<GamePass14>();
            if (gamePass != null)
            {
                gamePass.EnemyDown();
            }
        }
    }
 

    // Update is called once per frame
    void Update()
    {

        if (!isDead && hp <= 0)
        {
            isDead = true;
                    
            
            Invoke("Boomdied", 1f);


            GamePass14();




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

            GamePass14();
        }

    }


 

}









