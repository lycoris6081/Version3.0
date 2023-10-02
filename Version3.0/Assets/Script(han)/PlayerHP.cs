using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private Rigidbody2D rb;
    public static int hp = 2;

    public static bool Hp;
    public static bool Isdead;

    public GameObject gameOverUI; // 游戏结束UI
    // Start is called before the first frame update
    void Start()
    {
        hp = 2;
       
        gameOverUI.SetActive(false);
        Isdead = false;
        rb = GameObject.Find("CATCAT").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Playercontroller.isAttacking == false)
        {
            if (hp <= 0)
            {

                

                // 显示游戏结束UI
                gameOverUI.SetActive(true);

                Isdead = true;
            }
        }

       


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Playercontroller.isAttacking == false)
            {
                hp -= 1;

                // 计算反弹力
                Vector2 bounceForce = (transform.position - other.transform.position).normalized * 50f;
                // 施加反弹力到玩家刚体
                rb.AddForce(bounceForce, ForceMode2D.Impulse);

                Debug.Log("-1");
            }

        }
        if (other.gameObject.tag == "Bullet")
        {
            if (Playercontroller.isAttacking == false)
            {
                hp -= 1;
                Destroy(other.gameObject);
            }


        }

    }
    //private void OnColliderEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        if (Playercontroller.isAttacking == false)
    //        {
    //            hp -= 1;

    //            // 计算反弹力
    //            Vector2 bounceForce = (transform.position - other.transform.position).normalized *15f;
    //            // 施加反弹力到玩家刚体
    //            rb.AddForce(bounceForce, ForceMode2D.Impulse);

    //            Debug.Log("-1");
    //        }
           
    //    }
    //    if (other.gameObject.tag == "Bullet")
    //    {
    //        if (Playercontroller.isAttacking == false)
    //        {
    //            hp -= 1;
    //            Destroy(other.gameObject);
    //        }
            
           
    //    }

    //}
}
