using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public static int Damage = 1;
     
    private Rigidbody2D rb;
    void Start()
    {
      rb = GameObject.Find("CATCAT").GetComponent<Rigidbody2D>();
    }



   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Vector2 direction = (transform.position - other.transform.position).normalized;
            float knockbackForce = 100f; // 调整物理反馈力的大小
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        }
        if (other.gameObject.tag == "CUP")
        {
            Vector2 direction = (transform.position - other.transform.position).normalized;
            float knockbackForce = 80f; // 调整物理反馈力的大小
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        }
        if (other.gameObject.tag == "Enemy" && AbilityControl.AttckLevelUP)
        {
          
            GameObject gameManager = GameObject.Find("GameMenager");
            GamePass13 gamePass = gameManager.GetComponent<GamePass13>();
            if (gamePass != null)
            {
                gamePass.EnemyDowninAbility();
            }
        }
       

    }
}
