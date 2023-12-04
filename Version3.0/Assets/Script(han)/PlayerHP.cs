using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private Rigidbody2D rb;
    public static int hp = 3;
    public static int MaxHp = 3;
    public static bool Hp;
  
    public static bool Isdead;
    public static bool gameover;
    public GameObject gameOverUI; // 游戏结束UI
    public Image[] lifeImages; // 存放生命图像的数组
    private SpriteRenderer spriteRenderer;
    private float flashDuration = 0.1f;
    private Color originalColor;
    public bool isPlayingSound;


    AudioSource AudioSource;
    public AudioClip SFX_dieSound;
    public AudioClip SFX_hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;

        isPlayingSound = false;

        gameOverUI.SetActive(false);
        Isdead = false;
        gameover= false;
        rb = GameObject.Find("CATCAT").GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        AudioSource = GetComponent<AudioSource>();

    }
    private System.Collections.IEnumerator FlashWhite()
    {
        spriteRenderer.color = new Color32(255, 144, 144, 255);
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
    // Update is called once per frame
    void Update()
    {
        if(Playercontroller.isAttacking == false)
        {
            if (hp <= 0)
            {

                PlayDieSound();
                isPlayingSound = true;
                gameover = true;
                // 显示游戏结束UI
                gameOverUI.SetActive(true);

                Isdead = true;
            }
            else
            {
                gameover = false;
                // 显示游戏结束UI
                gameOverUI.SetActive(false);

                Isdead = false;
            }
           
        }

       


    }
    
    private void PlayDieSound()
    {
        if(isPlayingSound == false)
        {
            
            AudioSource.PlayOneShot(SFX_dieSound);
            Delayed(20);
            //isPlayingSound = false;
            Debug.Log("bapu");
        }

    }
    IEnumerator Delayed(float n)
    {

        yield return new WaitForSeconds(n); // 等待0.3秒

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Playercontroller.isAttacking == false)
            {
                hp -= 1;
                AudioSource.PlayOneShot(SFX_hurtSound);
                UpdateLifeUI(); // 更新生命图像
                StartCoroutine(FlashWhite());
                // 计算反弹力
                Vector2 bounceForce = (transform.position - other.transform.position).normalized * 100f;
                // 施加反弹力到玩家刚体
                rb.AddForce(bounceForce, ForceMode2D.Impulse);

                Debug.Log("-1");
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (Playercontroller.isAttacking == false&&Shield.shieldopen == false)
            {
                hp -= 1;
                UpdateLifeUI(); // 更新生命图像
                StartCoroutine(FlashWhite());
                // 计算反弹力
                Vector2 bounceForce = (transform.position - other.transform.position).normalized * 50f;
                // 施加反弹力到玩家刚体
                rb.AddForce(bounceForce, ForceMode2D.Impulse);

                Destroy(other.gameObject);
            }

        }
        if (other.gameObject.tag == "BOOM")
        {
            if (Playercontroller.isAttacking == false && Shield.shieldopen == false)
            {
                hp -= 2;
                UpdateLifeUI(); // 更新生命图像
                StartCoroutine(FlashWhite());

            }

        }
    }

    
    public void UpdateLifeUI()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < hp)
            {
                lifeImages[i].enabled = true; // 启用图像
            }
            else
            {
                lifeImages[i].enabled = false; // 禁用图像
            }
        }
    }

}
