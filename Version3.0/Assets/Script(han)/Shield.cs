using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;

    public static bool shieldopen = false;
    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
    }




    // Update is called once per frame
    void Update()
    {
        if (shieldopen)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (shieldopen)
            {
                // 计算反弹力
                Vector2 bounceForce = (other.transform.position - transform.position).normalized * 100f;

                // 获取敌人的刚体组件
                Rigidbody2D enemyRigidbody = other.gameObject.GetComponent<Rigidbody2D>();

                // 将反弹力应用于敌人
                enemyRigidbody.AddForce(bounceForce);

            }


        }


        if (other.gameObject.tag == "Bullet")
        {
            // 计算反弹力
            Vector2 bounceForce = (transform.position - other.transform.position).normalized * 100f;


            Destroy(other.gameObject);
        }


    }



}





