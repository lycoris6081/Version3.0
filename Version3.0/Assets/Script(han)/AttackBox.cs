using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public static bool enemyAttack = false;
    private Rigidbody2D rb;
    void Start()
    {
      rb = GameObject.Find("CATCAT").GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           enemyAttack = true;
          //  Destroy(other.gameObject);

            Vector2 direction = (transform.position - other.transform.position).normalized;
            float knockbackForce = 35f; // 调整物理反馈力的大小
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        }
        else
        {
            enemyAttack= false;
        }


    }
}
