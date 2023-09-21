﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 1f; // 子弹伤害值

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // 销毁子弹
            Destroy(gameObject);
        }
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    // 销毁子弹
        //    Destroy(gameObject);
        //}

    }

}