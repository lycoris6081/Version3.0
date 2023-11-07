using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUPBoomRange : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Player;

    void Start()
    {

        rb = GameObject.Find("CATCAT").GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CATCAT")
        {
            Vector2 direction = (transform.position - Player.transform.position).normalized;
            float knockbackForce = 150f; // 调整物理反馈力的大小
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        }
    }
}