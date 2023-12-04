using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 1f; // 子弹伤害值


  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            // 销毁子弹
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Shield"))
        {
            // 销毁子弹
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "EndLessWall")
        {
            // 销毁子弹
            Destroy(gameObject);

        }

    }
}
