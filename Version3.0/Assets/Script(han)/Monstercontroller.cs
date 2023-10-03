﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstercontroller : MonoBehaviour

{

    Animator animator;
    
    public int hp = 0;

    

    public enum Status { walk, attack };
    public Status status;
    public enum Face { Right, Left };
    public Face face;

    public GameObject SoulPrefab;

    public int minSouls = 1; // 最少掉落的灵魂数量
    public int maxSouls = 2; // 最多掉落的灵魂数量
    public float Speed;
    public float VerticalSpeed; //垂直移動變數
    private Transform myTransform;

    public Transform playerTransform;
    private SpriteRenderer spr;

    public Collider2D wallCollider; // 牆壁的碰撞器
    private bool isDead = false;




    void Start()
    {

        hp = 1;
        status = Status.walk;
        spr = this.transform.GetComponent<SpriteRenderer>();

        if (spr.flipX)
        {
            face = Face.Right;
        }
        else
        {
            face = Face.Left;
        }
        myTransform = this.transform;
        playerTransform = GameObject.Find("CATCAT").transform;

        //// 获取怪物的碰撞器
        //Collider2D monsterCollider = GetComponent<Collider2D>();

        //// 忽略与牆壁的碰撞
        //if (wallCollider != null && monsterCollider != null)
        //{
        //    Physics2D.IgnoreCollision(wallCollider, monsterCollider);
        //}
       animator = GetComponent<Animator>();
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
        
    }
   

    // Update is called once per frame
    void Update()
    {
  
       if (!isDead&&hp <= 0)
       {
          isDead = true;
          animator.SetFloat("Die", 1);
          Invoke("Dead", 0.2f);
          Invoke("SoulSpawn", 0.2f);
          
       }
       


        float deltaTime = Time.deltaTime;
        //STATUS UPDATE
        switch (status)
        {
            case Status.walk:
                if (myTransform.position.x >= playerTransform.position.x)
                {
                    spr.flipX = false;
                    face = Face.Left;
                }
                else
                {
                    spr.flipX = true;
                    face = Face.Right;
                }
                switch (face)

                {
                    case Face.Right:
                        myTransform.position += new Vector3(Speed * deltaTime, 0, 0);
                        break;
                    case Face.Left:
                        myTransform.position -= new Vector3(Speed * deltaTime, 0, 0);
                        break;
                }

                // 控制垂直移动
                if (myTransform.position.y < playerTransform.position.y)
                {
                    myTransform.position += new Vector3(0, VerticalSpeed * deltaTime, 0);
                }
                else if (myTransform.position.y > playerTransform.position.y)
                {
                    myTransform.position -= new Vector3(0, VerticalSpeed * deltaTime, 0);
                }
                break;



        }


    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackBox")
        {
            hp = hp -= AttackBox.Damage;

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("hit");
           collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }

}

   
    






