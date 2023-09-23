using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstercontroller : MonoBehaviour

{


    int hp = 0;
    public int max_hp = 0;

    public enum Status { walk, attack };
    public Status status;
    public enum Face { Right, Left };
    public Face face;

    public GameObject SoulPrefab;
    public float Speed;
    public float VerticalSpeed; //垂直移動變數
    private Transform myTransform;

    public Transform playerTransform;
    private SpriteRenderer spr;

    public Collider2D wallCollider; // 牆壁的碰撞器

  
    void Start()
    {
        max_hp = 1;
        hp = max_hp;
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
    }

    void SoulSpawn()
    {
         
       GameObject Soul = Instantiate(SoulPrefab, transform.position, Quaternion.identity);
 
       
       Destroy(Soul, 2f); // 假设2秒后销毁灵魂对象，根据需要进行调整
    }



    // Update is called once per frame
    void Update()
    {

        if (hp <= 0)
        {
            Destroy(this.gameObject);
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

          SoulSpawn();

            
        }

    }
}



